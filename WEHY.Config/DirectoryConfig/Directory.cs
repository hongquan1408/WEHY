using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEHY.Config.DirectoryConfig
{
    public static class Directory
    {
        public static string DirectoryPara = @"\Test\parameters";
        public static string ConfigFolder = DirectoryPara + @"\config";
        public static string InputFolder = @"\Test\input";

        public static string HillslopeParaFileName = @"\HillslopePara.xml";
        public static string GlobalParaFileName = @"\GlobalPara.xml";
        public static string ReachParaFileName = @"\ReachPara.xml";

        public static string HillslopePara = ConfigFolder + HillslopeParaFileName;
        public static string GlobalPara = ConfigFolder + GlobalParaFileName;
        public static string ReachPara = ConfigFolder + ReachParaFileName;

        public static string WEHYControlFileName = "WEHY2012_123.control";
        public static string R_Para_ChayFileName = "R_ch_para_chay.txt";
        public static string WEHYControl = DirectoryPara + @"\"+ WEHYControlFileName;
        public static string R_Para_Chay = DirectoryPara + @"\" + R_Para_ChayFileName;

        public static string Project_ParamsFolder = @"\Parameters";
        public static string Project_HillslopeFile = Project_ParamsFolder + HillslopeParaFileName;
        public static string Project_GlobalParaFile = Project_ParamsFolder + GlobalParaFileName;
        public static string Project_ReachParaFile = Project_ParamsFolder + ReachParaFileName;

        public static string Project_WEHYControl = Project_ParamsFolder + @"\" + WEHYControlFileName;
        public static string Project_R_Para_Chay = Project_ParamsFolder + @"\" + R_Para_ChayFileName;


        public static string RecentlyProject = @"\Test\RecentProject.xml";
    }
}
