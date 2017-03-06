using System;
using System.Collections.Generic;
using System.IO;
using WEHY.Config;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEHY.Business
{
    public class RenderBatchFile
    {
        string binfolder;
        public RenderBatchFile()
        {
            binfolder = Initialize.RootDirectory.Directory + @"\Test\bin\";
        }

        public void renderFileProcess1()
        {
            string WEHYexe = Initialize.RootDirectory.Directory + @"\Test\bin\WEHY2013_1231new.exe";
            string controlFile = Initialize.ProjectDirectory.Directory + @"\Parameters\WEHY2012_123.control";
            string paramFile = Initialize.ProjectDirectory.Directory + @"\Parameters\HydroParam.unf";
            string InputFolder = Initialize.ProjectDirectory.Directory + @"\Inputs\";
            string OtherParams = "noinit " + InputFolder + " 0 > WEHY2012_0411.log";
            string lineExe = WEHYexe + " " + controlFile + " " + paramFile + " " + OtherParams;

            string[] lines = { lineExe };
            string name = ProcessName.WEHYSimulation;
            createBatch(name, lines);
        }

        public void renderFileProcess2()
        {
            string csv2Routing11 = binfolder + "csv2Routing11";
            string workingDir = Initialize.ProjectDirectory.Directory + @"\outputs\";
            string OtherParamOfcsv2Routing = "0000 0.0";
            string lineCSV2Routing11 = csv2Routing11 + " " + workingDir + " " + OtherParamOfcsv2Routing;

            string changeDir = "cd" + " " + workingDir;
            string[] lines = { changeDir, lineCSV2Routing11 };
            string name = ProcessName.ConfigRiverChanelRoutingSimulation;
            createBatch(name, lines);
        }

        public void renderFileProcess3()
        {
            string usf10v1 = binfolder + "usf10v1";
            string usf10v1Params = Initialize.ProjectDirectory.Directory + @"\Parameters\R_ch_para_chay.txt";
            string hydrographFileName = Initialize.ProjectDirectory.Directory + @"\outputs\R_inflow.csv";
            string otherusf10v1Params = "  noinit  3";
            string lineusf10v1 = usf10v1 + " " + usf10v1Params + " " + hydrographFileName + otherusf10v1Params;

            string workingDir = Initialize.ProjectDirectory.Directory + @"\outputs\";
            string changeDir = "cd" + " " + workingDir;

            string[] lines = { changeDir, lineusf10v1 };
            string name = ProcessName.RiverChanelSimulation;
            createBatch(name, lines);
        }

        public void RenderAllProcess()
        {
            renderFileProcess1();
            renderFileProcess2();
            renderFileProcess3();
        }

        private void createBatch(string name, string[] process)
        {
            string path = Initialize.ProjectDirectory.Directory + name;
            File.WriteAllLines(path, process);
        }
    }
}
