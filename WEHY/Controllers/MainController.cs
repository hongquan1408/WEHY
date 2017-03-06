using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Business;

namespace WEHY.Controllers
{
     public class MainController
    {
        Views.Main form;
        public MainController(Views.Main MainForm)
        {
            form = MainForm;
        }

        public void CopyFile(string path)
        {
            string source = path;
            string dest = Business.Initialize.ProjectDirectory.Directory + Config.RequireInputsFiles.ATMvarYearly;
            System.IO.File.Copy(source, dest, true);
        }
    }
}
