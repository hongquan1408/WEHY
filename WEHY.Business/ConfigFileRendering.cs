using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Business.Initialize;
using WEHY.Config;
using WEHY.Config.RoutingConfig;
using System.Data;


namespace WEHY.Business
{
    public class ConfigFileRendering
    {
        
        public ConfigFileRendering()
        {
        }

        public void DeleteWEHYControl()
        {
            string path = RootDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.WEHYControl;
            File.Delete(path);
        }

        public void DeleteParaChay()
        {
            string path = RootDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.R_Para_Chay;
            File.Delete(path);
        }

        public void RenderParaChay()
        {
            XmlDataFinder XmlGlobalData = new XmlDataFinder(ProjectDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.Project_GlobalParaFile);
            var tab = "\t";
            string path = ProjectDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.Project_R_Para_Chay;
            TextWriter Stream = new StreamWriter(path);
            Stream.WriteLine(
                GlobalConfig.NREACH + tab +
                GlobalConfig.G + tab +
                GlobalConfig.TLAST + tab +
                GlobalConfig.OUTINT + tab +
                GlobalConfig.S_OUTLET + tab +
                GlobalConfig.TH_IC + tab +
                GlobalConfig.KAPPA + tab +
                GlobalConfig.LOW_D + tab +
                GlobalConfig.LOW_S + tab +
                GlobalConfig.L_out
                );
            Stream.WriteLine(
                XmlGlobalData.GetDataFromNode(GlobalConfig.NREACH,"data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.G, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.TLAST, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.OUTINT, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.S_OUTLET, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.TH_IC, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.KAPPA, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.LOW_D, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.LOW_S, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.L_out, "data")
                );
            Stream.WriteLine(
                GlobalConfig.S0MIN + tab +
                GlobalConfig.S0MAX + tab +
                GlobalConfig.R_INTAKE + tab +
                GlobalConfig.Y_GW0 + tab +
                GlobalConfig.LG_EXCH + tab +
                GlobalConfig.F_SFGW + tab +
                GlobalConfig.F_CMN + tab +
                GlobalConfig.F_WIDTH + tab +
                GlobalConfig.F_YIELD + tab +
                GlobalConfig.F_TRNS + tab +
                GlobalConfig.F_LEAK
                );
            Stream.WriteLine(
                XmlGlobalData.GetDataFromNode(GlobalConfig.S0MIN, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.S0MAX, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.R_INTAKE, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.Y_GW0, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.LG_EXCH, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.F_SFGW, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.F_CMN, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.F_WIDTH, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.F_YIELD, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.F_TRNS, "data") + tab +
                XmlGlobalData.GetDataFromNode(GlobalConfig.F_LEAK, "data")
                );
            Stream.WriteLine(
                ReachConfig.L + tab +
                ReachConfig.ID_R + tab +
                ReachConfig.NSEC + tab +
                ReachConfig.LENGTH + tab +
                ReachConfig.CH_WIDTH + tab +
                ReachConfig.BANK_S + tab +
                ReachConfig.MANNING + tab +
                ReachConfig.ELV_B + tab +
                ReachConfig.ELV_E + tab +
                ReachConfig.SFGW + tab +
                ReachConfig.UP_BC + tab +
                ReachConfig.DN_BC + tab +
                ReachConfig.Q_LT + tab +
                ReachConfig.MTHD + tab +
                ReachConfig.GW_WIDTH + tab +
                ReachConfig.SP_YIELD + tab +
                ReachConfig.TRNS + tab +
                ReachConfig.R_LEAK
                );
            DataSet data = new DataSet();

            data.ReadXml(ProjectDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.Project_ReachParaFile);
            foreach(DataRow record in data.Tables["ReachParams"].Rows)
            {
                Stream.WriteLine(
                    record[ReachConfig.L] + tab +
                    record[ReachConfig.ID_R] + tab +
                    record[ReachConfig.NSEC] + tab +
                    record[ReachConfig.LENGTH] + tab +
                    record[ReachConfig.CH_WIDTH] + tab +
                    record[ReachConfig.BANK_S] + tab +
                    record[ReachConfig.MANNING] + tab +
                    record[ReachConfig.ELV_B] + tab +
                    record[ReachConfig.ELV_E] + tab +
                    record[ReachConfig.SFGW] + tab +
                    record[ReachConfig.UP_BC] + tab +
                    record[ReachConfig.DN_BC] + tab +
                    record[ReachConfig.Q_LT] + tab +
                    record[ReachConfig.MTHD] + tab +
                    record[ReachConfig.GW_WIDTH] + tab +
                    record[ReachConfig.SP_YIELD] + tab +
                    record[ReachConfig.TRNS] + tab +
                    record[ReachConfig.R_LEAK]
                    );
            }

            Stream.Close();
        }

        public void RenderWEHYControl() {
            XmlDataFinder XmlHillsopeData = new XmlDataFinder(ProjectDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.Project_HillslopeFile);
            string path = ProjectDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.Project_WEHYControl;
            string[] lines = 
            {
                "&DXNTcontrol",
                HillslopeConfig.alfsdp + " = 4"  ,
                HillslopeConfig.alfKs + " = 6" ,
                "/",
                "!",
                HillslopeConfig.NXhs0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.NXhs0,"data"),
                HillslopeConfig.NXrl0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.NXrl0,"data"),
                HillslopeConfig.NThs + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.NThs,"data"),
                HillslopeConfig.NTrl + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.NTrl,"data"),
                HillslopeConfig.alfKs + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.alfKs,"data"),
                HillslopeConfig.alfsdp + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.alfsdp,"data"),
                HillslopeConfig.alfroot + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.alfroot,"data"),
                HillslopeConfig.woleaf + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.woleaf,"data"),
                HillslopeConfig.czrl + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.czrl,"data"),
                HillslopeConfig.czov + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.czov,"data"),
                HillslopeConfig.bwrl0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.bwrl0,"data"),
                HillslopeConfig.srinit + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.srinit,"data"),
                HillslopeConfig.albedos0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.albedos0,"data"),
                HillslopeConfig.albedow0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.alfsdp,"data"),
                HillslopeConfig.roughs0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.roughs0,"data"),
                HillslopeConfig.roughw0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.roughw0,"data"),
                HillslopeConfig.vlai0 + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.vlai0,"data"),
                HillslopeConfig.RMXMN_albedo + " = " + XmlHillsopeData.GetDataFromNode(Months.Jan, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Feb, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Mar, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Apr, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.May, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Jun, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Jul, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Aug, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Sep, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Oct, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Nov, "data/"+ HillslopeConfig.RMXMN_albedo) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Dec, "data/"+ HillslopeConfig.RMXMN_albedo) + ",",
                HillslopeConfig.RMXMN_z0 + " = " + XmlHillsopeData.GetDataFromNode(Months.Jan, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Feb, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Mar, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Apr, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.May, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Jun, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Jul, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Aug, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Sep, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Oct, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Nov, "data/"+ HillslopeConfig.RMXMN_z0) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Dec, "data/"+ HillslopeConfig.RMXMN_z0) + ",",
                HillslopeConfig.adjprec + " = " + XmlHillsopeData.GetDataFromNode(Months.Jan, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Feb, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Mar, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Apr, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.May, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Jun, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Jul, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Aug, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Sep, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Oct, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Nov, "data/"+ HillslopeConfig.adjprec) + ","
                                                     + XmlHillsopeData.GetDataFromNode(Months.Dec, "data/"+ HillslopeConfig.adjprec) + ",",
                HillslopeConfig.DEPTH_SLAB + " = " + XmlHillsopeData.GetDataFromNode("DEPTHSLAB","data"),
                HillslopeConfig.DENSG + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.DENSG,"data"),
                HillslopeConfig.CG + " = " + XmlHillsopeData.GetDataFromNode(HillslopeConfig.CG,"data"),
            };
            File.WriteAllLines(path, lines);
        }
    }
}
