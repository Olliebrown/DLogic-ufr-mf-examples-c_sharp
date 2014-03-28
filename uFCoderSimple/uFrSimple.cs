using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace uFRSimple
{
    static class uFrSimple
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmuFRSimpleImplementation());
        }
    }
}
