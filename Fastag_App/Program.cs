using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fatag_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool CreatedOn;
            var mutex = new System.Threading.Mutex(true, "Fastag_SATO", out CreatedOn);
            if (!CreatedOn)
            {
                MessageBox.Show("Application already running", "Fastag_SATO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            
            Application.Run(new frmLogin());
        }
    }
}
