using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDS_Intrussion_Detection_System_.BackEnd.ProcessWatcher;

namespace IDS_Intrussion_Detection_System_.BackEnd {
    public class Utilites {
        public static ProcessWrapper GetProcess(ArrayList processList, ProcessWrapper key) {
            foreach(ProcessWrapper process in processList) {
                if(process != null && process.getName().Equals(key.getName())) {
                    return process;
                }
            }
            return null;
        }
        public static bool SearchProcess(ArrayList processList, ProcessWrapper key) {
            ProcessWrapper process = GetProcess(processList, key);
            if(process == null) {
                return false;
            }
            return true;
        }
        public static bool SearchProcess(ArrayList processList, String processName) {
            return SearchProcess(processList, new ProcessWrapper(processName));
        }
        public static ProcessWrapper GetProcess(ArrayList processList, String processName) {
            return GetProcess(processList, new ProcessWrapper(processName));
        }
    }
}
