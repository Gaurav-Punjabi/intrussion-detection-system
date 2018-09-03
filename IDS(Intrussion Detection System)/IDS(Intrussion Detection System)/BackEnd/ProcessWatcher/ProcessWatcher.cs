using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Management;
using IDS_Intrussion_Detection_System_.BackEnd;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace IDS_Intrussion_Detection_System_.BackEnd.ProcessWatcher {
    public class ProcessWatcher {
        public ProcessWatcher() {
            //Getting the list of installed applications...
            this.processList = GetInstalledApplications();
            //Initializing the watcher..
            watcher = new ManagementEventWatcher("SELECT * FROM Win32_ProcessStartTrace");
            watcher.EventArrived += ProcessStarted;
            watcher.Scope.Options.EnablePrivileges = true;
            watcher.Start();
            MessageBox.Show(processList.Count + "");
            Utilites.GetProcess(processList, new ProcessWrapper("sublime_text.exe")).setAcessible(true);
            if(Process.GetProcessesByName("chrome.exe") != null && Process.GetProcessesByName("chrome.exe").Length > 0)
                MessageBox.Show(Process.GetProcessesByName("chrome.exe")[0].ProcessName);
        }
        private ArrayList GetInstalledApplications() {
            XmlHandler processXml = new XmlHandler(Constants.PROCESS_LIST_PATH);
            Log[] logs = processXml.GetLogs();
            ArrayList processList = new ArrayList();
            for(int i=0;i<logs.Length;i++) {
                processList.Add(new ProcessWrapper(logs[i].getName()));
                MessageBox.Show(logs[i].getName());
            }
            return processList;
        }
        private void ProcessStarted(object sender, EventArrivedEventArgs e) {
            String name = ((string)e.NewEvent.Properties["ProcessName"].Value);
            String processName = name.Replace(".exe", "");
            if(Utilites.SearchProcess(processList, name)) {
                if(Utilites.GetProcess(processList, name).isAccessible()) {
                    Process[] processes = Process.GetProcessesByName(processName);
                    if(processes != null && processes.Length > 0) {
                        foreach(Process process in processes) {
                            process.Kill();
                        }
                        MessageBox.Show("Process " + processName + " has been killed.");
                    }
                }
                else {
                    MessageBox.Show(name + " process started.");
                }
            }
        }
        private ManagementEventWatcher watcher;
        private ArrayList processList;
    }
}
