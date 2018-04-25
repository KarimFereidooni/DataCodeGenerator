using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataCodeGenerator
{
    static class Program
    {
        private static string _LoginName;
        public static string LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(UI.Main.Instance);
        }
    }
}
