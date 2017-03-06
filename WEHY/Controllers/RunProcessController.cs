using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEHY.Controllers
{
    public class RunProcessController
    {
        WEHY.Business.RenderBatchFile BatchFile;
        private string missingFile;
        public RunProcessController()
        {
            BatchFile = new Business.RenderBatchFile();
            missingFile = "";
        }

        public string GetMissingFile()
        {
            return missingFile;
        }

        
        private bool FileCheck(string path)
        {
            if (File.Exists(path))
                return true;
            else
            {
                missingFile = path;
                return false;
            }
        }

        private bool CheckParamsFile()
        {
            string HidroParams = Business.Initialize.ProjectDirectory.Directory + Config.RequireParamsFiles.HydroParam;
            string DR_MCU = Business.Initialize.ProjectDirectory.Directory + Config.RequireParamsFiles.DR_MCU;
            string KC_MCU = Business.Initialize.ProjectDirectory.Directory + Config.RequireParamsFiles.KC_MCU;
            string LAI_MCU = Business.Initialize.ProjectDirectory.Directory + Config.RequireParamsFiles.LAI_MCU;
            string SR_MCU = Business.Initialize.ProjectDirectory.Directory + Config.RequireParamsFiles.SR_MCU;

            return FileCheck(HidroParams) && FileCheck(DR_MCU) && FileCheck(KC_MCU) && FileCheck(LAI_MCU) && FileCheck(SR_MCU);
        }

        private bool CheckInputFile()
        {
            string ATMvarYearly = Business.Initialize.ProjectDirectory.Directory + Config.RequireInputsFiles.ATMvarYearly;
            string DeepSoilTdem = Business.Initialize.ProjectDirectory.Directory + Config.RequireInputsFiles.DeepSoilTdem;

            return FileCheck(ATMvarYearly) && FileCheck(DeepSoilTdem);
        }

        public bool CheckFile()
        {
            return CheckInputFile() && CheckParamsFile();
        }

        public void RunWEHYSimulation()
        {
            BatchFile.renderFileProcess1();
            _RunBatFile(WEHY.Config.ProcessName.WEHYSimulation);
        }

        public void RunConfigRiverChanel()
        {
            BatchFile.renderFileProcess2();
            _RunBatFile(WEHY.Config.ProcessName.ConfigRiverChanelRoutingSimulation);
        }

        public void RunRiverChanelSimulation()
        {
            BatchFile.renderFileProcess3();
            _RunBatFile(WEHY.Config.ProcessName.RiverChanelSimulation);
        }

        public void RunAllProcess()
        {
            RunWEHYSimulation();
            RunConfigRiverChanel();
            RunRiverChanelSimulation();
            
        }

        private void _RunBatFile(string FileName)
        {
            string WorkingDir = Business.Initialize.ProjectDirectory.Directory;
            FileName = FileName.Replace(@"\", string.Empty);

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.WorkingDirectory = WorkingDir;
            proc.StartInfo.FileName = FileName;
            proc.Start();
            proc.WaitForExit();
        }
    }
}
