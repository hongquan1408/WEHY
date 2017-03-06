using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Views.File;

namespace WEHY.Controllers
{
    public class SaveAsController
    {
        SaveProjectAs form;
        public SaveAsController(SaveProjectAs saveProjectAs)
        {
            form = saveProjectAs;
        }

        public void SaveAsProject(string directory, string name)
        {
            Business.CloneProject Cloner = new Business.CloneProject(directory, name);
            Cloner.Clone();
            Cloner.ChangeProject();
        }
    }
}
