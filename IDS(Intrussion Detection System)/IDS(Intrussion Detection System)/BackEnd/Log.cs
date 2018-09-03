using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS_Intrussion_Detection_System_.BackEnd {
    public class Log {
        private String path;
        private String name;
        private String oldName;
        public int Type { get; set; }

        public const int FILE_RENAMED_LOG = 1;
        public const int FILE_DELETED_LOG = 2;
        public const int FILE_CREATED_LOG = 3;
        public const int FILE_CHANGED_LOG = 4;
        public const int PROCESS_CREATED_LOG = 5;
        public const int PROCESS_DESTROYED_LOG = 6;
        public const int PROCESS_LOG = 7;

        public Log(String path, String name, String oldName, int type) {
            this.path = path;
            this.name = name;
            this.oldName = oldName;
            this.Type = type;
        }
        public Log(String path, String name, int type) : this(path, name, "", type) { }
        public Log(String name, int type) : this("" , name, "", type) { }
        public Log() : this("", "", "", 0) { }

        public String getPath() {
            return this.path;
        }
        public String getName() {
            return this.name;
        }
        public String getOldName() {
            return this.oldName;
        }
        public void setPath(String path) {
            this.path = path;
        }
        public void setName(String name) {
            this.name = name;
        }
        public void setOldName(String oldName) {
            this.oldName = oldName;
        }
    }
}
