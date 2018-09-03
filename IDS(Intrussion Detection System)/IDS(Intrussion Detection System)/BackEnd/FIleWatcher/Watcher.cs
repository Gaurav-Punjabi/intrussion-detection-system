using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDS_Intrussion_Detection_System_.BackEnd;
using System.IO;

namespace IDS_Intrussion_Detection_System_.BackEnd.FileWatcher {
    /**
     * <summary>
     *      <para>The class <c>Watcher</c> is used to watch the Files to a given particular folder</para>
     *      <para>This would listen to all the changes made to the target and store all the logs on all types of actions.</para>
     * </summary>
     */
    public class FileWatcher {
        /**
         * *****************************************************************
         *                          VARIABLE DECLARATION
         * *****************************************************************
         */
        private FileSystemWatcher fileSystemWatcher;
        private String path;
        private XmlHandler xmlHandler, temp;


        /**
         * *****************************************************************
         *                         CONSTRUCTOR
         *  ****************************************************************
         *  This is just a simple constructor for intitalization for the variables and the file watcher itselt
         *  <param name="path">The path to the folder that needs to be monitored.</param>
         **/
        public FileWatcher(String path) {
            //Checking Whether the given path is a directory or not
            if(!IsDirectory(path)) {
                System.Windows.Forms.MessageBox.Show("Please give the path of a directory.");
                return;
            }
            fileSystemWatcher = new FileSystemWatcher(path);
            xmlHandler = new XmlHandler(Constants.LOG_XML_PATH);
            temp = new XmlHandler(Constants.TEMP_XML_PATH);
            this.path = path;
            //Backing up the data
            Backup(path,"C:\\Users\\tamanna\\Desktop\\Backup");


            //Adding Listeners to Events
            fileSystemWatcher.Changed += FileChanged;
            fileSystemWatcher.Renamed += FileRenamed;
            fileSystemWatcher.Created += FileCreated;
            fileSystemWatcher.Deleted += fileDeleted;

            //Configuring the FileSystemWatcher object..
            fileSystemWatcher.IncludeSubdirectories = true;
            StartMonitoring();
        }

        public void StopMonitoring() {
            this.fileSystemWatcher.EnableRaisingEvents = false;
        }

        private void fileDeleted(object sender, FileSystemEventArgs e) {
            fileSystemWatcher.EnableRaisingEvents = false;
            lock (temp) {
                temp.AddDeletedLog(e.Name, e.FullPath);
            }
            fileSystemWatcher.IncludeSubdirectories = true;
        }
        public void StartMonitoring() {
            this.fileSystemWatcher.EnableRaisingEvents = true;
        }

        /**
         * <summary>This is just the delegate of the event that makes an entry of created log.</summary>
         * <param name="e">The FileSystemEventArgs</param>
         * <param name="sender">The reference of the event generator.</param>
         */
        private void FileCreated(object sender, FileSystemEventArgs e) {
            fileSystemWatcher.EnableRaisingEvents = false;
            lock(temp) {
                temp.AddCreatedLog(e.Name, e.FullPath);
            }
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void FileRenamed(object sender, RenamedEventArgs e) {
            fileSystemWatcher.EnableRaisingEvents = false;
            lock(temp) {
                temp.AddRenameLog(e.OldName, e.Name, e.FullPath);
            }
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void FileChanged(object sender, FileSystemEventArgs e) {
            fileSystemWatcher.EnableRaisingEvents = false;
            lock(temp) {
                temp.AddChangedLog(e.Name, e.FullPath);
            }
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        /**
         * <summary>
         * This method is used to parse the whole file and back it up to the given destination path.
         * </summary>
         * <param name="destination">The path to the destination Folder</param>
         * <param name="source">The path to the destination Folder</param>
         */
        public void Backup(String source,String destination) {
            foreach(String entry in Directory.GetFileSystemEntries(source))
            {
                if (File.Exists(entry))
                {
                    AddFile(entry, destination + entry.Replace(source,""));
                }
                else if (Directory.Exists(entry))
                {
                    AddDirectory(entry, destination + entry.Replace(source,""));
                }
            }
        }
        
        /**
         * <<summary>This method is used to Make a copy of the file to the given destination.</summary>
         * <param name="source">The path to the source file</param>
         * <param name="destination">The path to the destination file</param>
         * <exception cref="ArgumentException">This exception is thrown when a path to a directory is not provided in the source.</exception>
         * */
        private void AddFile(String source,String destination) {
            if(File.Exists(source)) {
                String content = File.ReadAllText(source);
                File.WriteAllText(destination, content);
                return;
            }
            throw new ArgumentException("Need to pass a path to the file.");
        }
        private void AddDirectory(String path, String destination) {
            Directory.CreateDirectory(destination);
            Backup(path, destination);
        }
        private bool IsDirectory(String path) {
            FileAttributes attributes = File.GetAttributes(path);

            if (attributes.HasFlag(FileAttributes.Directory))
                return true;

            return false;
        }
    }
}
