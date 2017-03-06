using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Business;

namespace WEHY.Controllers.Common
{
    public class RecentProjectCommon
    {
        XmlDataFinder RecentProjectDirectory;

        public RecentProjectCommon()
        {
            RecentProjectDirectory = new XmlDataFinder(Business.Initialize.RootDirectory.Directory + Config.DirectoryConfig.Directory.RecentlyProject);
        }

        public string getRecentlyProjectPath()
        {
            string node = "recent-project";
            var path = RecentProjectDirectory.GetDataFromNode(node, "data");
            return path;
        }

        public void setRecentlyProjectPath(string path)
        {
            string node = "recent-project";
            RecentProjectDirectory.SetDataToNode(node, path);
        }
    }
}
