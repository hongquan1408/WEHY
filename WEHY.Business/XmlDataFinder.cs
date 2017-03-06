using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Config.DirectoryConfig;
using System.Xml;
using WEHY.Business.Initialize;

namespace WEHY.Business
{
    public class XmlDataFinder
    {
        XmlDocument Doc;
        string FileDirectory;
        string ProjectDir;

        public XmlDataFinder(string Directory)
        {
            Doc = new XmlDocument();
            FileDirectory = Directory;
            Doc.Load(FileDirectory);
        }

        public string GetDataFromNode(string NodeName,string node)
        {
            XmlNode Node = Doc.SelectSingleNode(node);
            return Node[NodeName].InnerText;
        }

        public void SetDataToNode(string node, string value)
        {
            XmlNode Node = Doc.SelectSingleNode("data/"+node);
            Node.InnerText = value;
            Doc.Save(FileDirectory);
        }
    }
}
