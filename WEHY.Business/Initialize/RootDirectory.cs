using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace WEHY.Business.Initialize
{
    public static class RootDirectory
    {
        private static string _Root = "";
        public static string Directory
        {
            get { return _Root; }
            set { _Root = value; }
        }
    }

    public sealed class ProjectDirectory
    {
        private static string _Project = "";
        public delegate void ChangeHandler(string directory);
        public static ChangeHandler Change;

        public static string Directory
        {
            get { return _Project; }
            set {
                _Project = value;
                if (Change != null)
                    Change(Directory);
            }
        }
    }

    public static class ProjectName
    {
        private static string _ProjectName = "";
        public static string Name
        {
            get { return _ProjectName; }
            set
            {
                _ProjectName = value;
            }
        }
    }
}
