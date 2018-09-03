using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS_Intrussion_Detection_System_.UserInterface {
    public partial class FileIDS : Form {
        public FileIDS() {
            InitializeComponent();
            AddItems();
        }

        private void AddItems() {
            int y = 0;
            for(int i=0;i<32;i++) {
                Components.FileLogItem fileLogItem = new Components.FileLogItem("Name of the Designer");
                fileLogItem.Location = new System.Drawing.Point(0, y);
                y += fileLogItem.Size.Height;
                this.pnlList.Controls.Add(fileLogItem);
            }
        }
    }
}
