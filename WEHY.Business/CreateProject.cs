using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace WEHY.Business
{
    public class CreateProject
    {
        private string ProjectDirectory;
        private string ProjectName;
        private string FullDirectory;

        public CreateProject(string ProjectDirectory, string ProjectName)
        {
            this.ProjectDirectory = ProjectDirectory;
            this.ProjectName = ProjectName;
            FullDirectory = Path.Combine(this.ProjectDirectory, this.ProjectName);
            CreateFolderProject();
            CreateWEHYFile();
            CreateIOFolder();
            CreateConfigFile();
            CreateInputFile();
            WEHY.Business.Initialize.ProjectDirectory.Directory = FullDirectory;
            Business.Initialize.ProjectName.Name = ProjectName;
        }

        private void CreateFolderProject()
        {
            Directory.CreateDirectory(FullDirectory);
        }

        private void CreateWEHYFile()
        {
            string path = Path.Combine(FullDirectory, ProjectName + ".wehy");
            XmlDocument xmlFile = new XmlDocument();

            XmlElement rootElement = xmlFile.CreateElement(string.Empty, "data", string.Empty);
            xmlFile.AppendChild(rootElement);

            XmlNode Node = xmlFile.CreateElement(string.Empty, "project-name", string.Empty);
            Node.InnerText = this.ProjectName;

            rootElement.AppendChild(Node);
            xmlFile.Save(path);
        }

        private void CreateIOFolder()
        {
            string pathInputsFolder = Path.Combine(this.FullDirectory, "Inputs");
            string pathOutputsFolder = Path.Combine(this.FullDirectory, "outputs");
            string ParamsFolder = Path.Combine(this.FullDirectory, "Parameters");

            Directory.CreateDirectory(pathInputsFolder);
            Directory.CreateDirectory(pathOutputsFolder);
            Directory.CreateDirectory(ParamsFolder);
        }

        private void CreateConfigFile()
        {
            string[] files = Directory.GetFiles(WEHY.Business.Initialize.RootDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.ConfigFolder);
            string fileName,
                   destFile;
            foreach(string file in files)
            {
                fileName = Path.GetFileName(file);
                destFile = Path.Combine(Path.Combine(FullDirectory, "Parameters"), fileName);
                File.Copy(file, destFile, true);
            }
        }

        private void CreateInputFile()
        {
            string[] files = Directory.GetFiles(WEHY.Business.Initialize.RootDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.InputFolder);
            string fileName,
                   destFile;
            foreach (string file in files)
            {
                fileName = Path.GetFileName(file);
                destFile = Path.Combine(Path.Combine(FullDirectory, "Inputs"), fileName);
                File.Copy(file, destFile, true);
            }
        }
    }
}
