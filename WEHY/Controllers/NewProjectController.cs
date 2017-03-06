using System;
using System.Collections.Generic;
using System.Linq;
using WEHY.Business;
using WEHY.Views.File;
using System.Text;
using System.Threading.Tasks;



namespace WEHY.Controllers
{
    public class NewProjectController
    {
        NewProject thisForm;
        ConfigFileRendering RenderFile;

        public NewProjectController(NewProject form)
        {
            thisForm = form;
            RenderFile = new ConfigFileRendering();
        }

        public void CreateProject(string directory, string name)
        {
            CreateProject ProjectCreator = new CreateProject(directory, name);
            RenderFile.RenderWEHYControl();
            RenderFile.RenderParaChay();
        }
    }
}
