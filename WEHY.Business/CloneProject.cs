using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WEHY.Business
{
    public class CloneProject
    {
        string path;
        string name;
        string FullPath;
        public CloneProject(string path, string name)
        {
            this.path = path;
            this.name = name;
            this.FullPath = Path.Combine(path, name);
        }

        private void CreateFolder()
        {
            Directory.CreateDirectory(FullPath);
        }

        public void Clone()
        {
            CreateFolder();
            string SourcePath = Initialize.ProjectDirectory.Directory;
            string DestinationPath = FullPath;

            foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
             SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));

            foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(SourcePath, DestinationPath), true);
        }

        public void ChangeProject()
        {
            Initialize.ProjectDirectory.Directory = FullPath;
            string ProjectFile = FullPath + @"\" + Initialize.ProjectName.Name;
            string NewName = name + ".wehy";
            string ProjectFileWithNewName = FullPath + @"\"+ NewName;

            XmlDataFinder DataChange = new XmlDataFinder(ProjectFile);
            DataChange.SetDataToNode("project-name", NewName);

            System.IO.File.Move(ProjectFile, ProjectFileWithNewName);
            Initialize.ProjectName.Name = NewName;
        }
    }
}
