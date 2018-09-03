using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Intrussion_Detection_System_.BackEnd.ProcessWatcher {
    public class ProcessWrapper {
        private string name;
        private bool accessible;

        public ProcessWrapper() : this("", false) { }
        public ProcessWrapper(String name) : this(name, false) { }
        public ProcessWrapper(String name, bool accessible) {
            setName(name);
            setAcessible(accessible);
        } 

        public string getName() {
            return name;
        }
        public bool isAccessible() {
            return accessible;
        }
        public void setName(String name) {
            this.name = name;
        }
        public void setAcessible(bool accessible) {
            this.accessible = accessible;
        }
    }
}
