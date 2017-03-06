using System;
using System.Windows.Forms;
using WEHY.Views;
using WEHY.Business.Initialize;
using System.IO;

namespace WEHY
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
            Init init = new Init();
            Application.Run(new Main());
        }
    }
}
