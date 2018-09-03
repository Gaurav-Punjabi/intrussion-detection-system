using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDS_Intrussion_Detection_System_.UserInterface;
using IDS_Intrussion_Detection_System_.BackEnd;
using IDS_Intrussion_Detection_System_.BackEnd.FileWatcher;
using IDS_Intrussion_Detection_System_.BackEnd.ProcessWatcher;
using System.IO;

namespace IDS_Intrussion_Detection_System_
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.Run(new FileIDS());
        }
    }
}
