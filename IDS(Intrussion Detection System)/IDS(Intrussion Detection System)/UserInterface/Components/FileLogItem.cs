using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDS_Intrussion_Detection_System_.UserInterface.Components {
    public partial class FileLogItem : UserControl {
        public FileLogItem(String name) {
            InitializeComponent();
            this.lblTitle.Text = name;
        }
    }
}
