using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Diagnostics;
using IDS_Intrussion_Detection_System_.BackEnd.FileWatcher;
using System.Windows.Forms;

namespace IDS_Intrussion_Detection_System_.BackEnd
{
    public class XmlHandler {

        private XmlDocument writer;
        private XmlNode rootNode;
        private String path;
        private const String RENAME_TAG = "rename";
        private const String CREATED_TAG = "created";
        private const String DELETED_TAG = "deleted";
        private const String CHANGED_TAG = "changed";
        private const String PROCESS_TAG = "process";

        public XmlHandler(String path) {
            this.path = path;
            writer = new XmlDocument();
            if (File.Exists(path)) {
                try {
                    writer.Load(path);
                    rootNode = writer.SelectNodes("logs")[0];
                } catch (Exception) { }
            } else {
                File.Create(path);
                File.AppendAllText(path, "<logs>\n</logs>");
                this.rootNode = writer.SelectNodes("logs")[0];
                //writer.Save(path);
            }
        }

        public void AddRenameLog(String oldName, String newName, String path) {
            XmlElement renameElement = writer.CreateElement(RENAME_TAG);
            XmlAttribute nameAttribute = writer.CreateAttribute("name");
            XmlAttribute pathAttribute = writer.CreateAttribute("path");
            nameAttribute.Value = newName;
            pathAttribute.Value = path;
            renameElement.InnerText = oldName;
            renameElement.Attributes.Append(nameAttribute);
            renameElement.Attributes.Append(pathAttribute);
            rootNode.AppendChild(renameElement);
            writer.Save(this.path);
        }

        public void AddCreatedLog(String name, String path) {
            XmlElement createdElement = writer.CreateElement(CREATED_TAG);
            XmlAttribute pathAttribute = writer.CreateAttribute("path");
            pathAttribute.Value = path;
            createdElement.InnerText = name;
            createdElement.Attributes.Append(pathAttribute);
            this.rootNode.AppendChild(createdElement);
            this.writer.Save(this.path);
        }

        public void AddDeletedLog(String name, String path) {
            XmlElement deletedElement = writer.CreateElement(DELETED_TAG);
            XmlAttribute pathAttribute = writer.CreateAttribute("path");
            pathAttribute.Value = path;
            deletedElement.InnerText = name;
            deletedElement.Attributes.Append(pathAttribute);
            this.rootNode.AppendChild(deletedElement);
            this.writer.Save(this.path);
        }
        
        public void AddProcessLog(String name) {
            XmlElement processElement = writer.CreateElement(PROCESS_TAG);
            //XmlAttribute pathAttribute = writer.CreateAttribute("path");
            //pathAttribute.Value = path;
            processElement.InnerText = name;
            //processElement.Attributes.Append(pathAttribute);
            this.rootNode.AppendChild(processElement);
            this.writer.Save(this.path);
        }

        public void AddChangedLog(String name, String path) {
            XmlElement changedElement = writer.CreateElement(CHANGED_TAG);
            XmlAttribute pathAttribute = writer.CreateAttribute("path");
            pathAttribute.Value = path;
            changedElement.InnerText = name;
            changedElement.Attributes.Append(pathAttribute);
            this.rootNode.AppendChild(changedElement);
            this.writer.Save(this.path);
        }

        public void RemoveAll() {
            this.rootNode.RemoveAll();
        }

        public Boolean deleteLog(Log target) {
            if(target == null) {
                return false;
            }
            int index = this.indexOf(target);
            if(index < 0) {
                return false;
            }
            XmlNode nodeToDelete = writer.SelectNodes("logs/*")[index];
            Debug.WriteLine(nodeToDelete.Name);
            this.rootNode.RemoveChild(nodeToDelete);
            this.writer.Save(this.path);
            return true;
             
        }
        public int indexOf(Log key) {
            Log[] logs = GetLogs();
            int index = 0;
            foreach (Log log in logs) {
                if (log.getPath().Equals(key.getPath()) && log.Type == key.Type) {
                    return index;
                }
                index++;
            }
            return -1;
        }
        public Log[] GetLogs() {
            LinkedList<Log> logs = new LinkedList<Log>();
            XmlNodeList nodes = writer.SelectNodes("logs/*");
            foreach(XmlNode node in nodes) {
                switch (node.Name) {
                    case RENAME_TAG:
                        Log renameLog = new Log(node.Attributes["path"].Value, node.InnerText, node.Attributes["name"].Value, Log.FILE_RENAMED_LOG);
                        logs.AddLast(renameLog);
                        break;

                    case CREATED_TAG:
                        Log createdLog = new Log(node.Attributes["path"].Value, node.InnerText, Log.FILE_CREATED_LOG);
                        logs.AddLast(createdLog);
                        break;

                    case CHANGED_TAG:
                        Log changedLog = new Log(node.Attributes["path"].Value, node.InnerText, Log.FILE_CHANGED_LOG);
                        logs.AddLast(changedLog);
                        break;

                    case DELETED_TAG:
                        Log deletedLog = new Log(node.Attributes["path"].Value, node.InnerText, Log.FILE_DELETED_LOG);
                        logs.AddLast(deletedLog);
                        break;

                    case PROCESS_TAG:
                        Log processLog = new Log(node.Attributes["path"].Value, node.InnerText, Log.PROCESS_LOG);
                        logs.AddLast(processLog);
                        break;
                }
            }
            return logs.ToArray();
        }
    }
}
