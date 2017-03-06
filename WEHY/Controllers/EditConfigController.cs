using System;
using WEHY.Business;
using WEHY.Views.Config;
using System.Windows.Forms;
using WEHY.Config.DirectoryConfig;
using WEHY.Config;
using WEHY.Config.RoutingConfig;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WEHY.Business.Initialize;

namespace WEHY.Controllers
{
    public class EditConfigController
    {
        XmlDataFinder XmlData;
        XmlDataFinder XmlDataGlobals;

        XmlDataFinder Default_XmlData;
        XmlDataFinder Default_XmlDataGlobals;

        EditConfig thisForm;
        ConfigFileRendering RenderFile;
        public EditConfigController(EditConfig form)
        {
            thisForm = form;
            XmlData = new XmlDataFinder(WEHY.Business.Initialize.ProjectDirectory.Directory + Directory.Project_HillslopeFile);
            XmlDataGlobals = new XmlDataFinder(WEHY.Business.Initialize.ProjectDirectory.Directory + Directory.Project_GlobalParaFile);

            Default_XmlData = new XmlDataFinder(WEHY.Business.Initialize.RootDirectory.Directory + Directory.HillslopePara);
            Default_XmlDataGlobals = new XmlDataFinder(WEHY.Business.Initialize.RootDirectory.Directory + Directory.GlobalPara);
            RenderFile = new ConfigFileRendering();
        }

        public void SaveConfig()
        {

            //Hillslope Params Data
            XmlData.SetDataToNode(HillslopeConfig.NXhs0, GetTextBoxValue(HillslopeConfig.NXhs0));
            XmlData.SetDataToNode(HillslopeConfig.NXrl0, GetTextBoxValue(HillslopeConfig.NXrl0));
            XmlData.SetDataToNode(HillslopeConfig.NThs, GetTextBoxValue(HillslopeConfig.NThs));
            XmlData.SetDataToNode(HillslopeConfig.NTrl, GetTextBoxValue(HillslopeConfig.NTrl));
            XmlData.SetDataToNode(HillslopeConfig.alfKs, GetTextBoxValue(HillslopeConfig.alfKs));
            XmlData.SetDataToNode(HillslopeConfig.alfsdp, GetTextBoxValue(HillslopeConfig.alfsdp));
            XmlData.SetDataToNode("DEPTHSLAB", GetTextBoxValue(HillslopeConfig.DEPTH_SLAB));
            XmlData.SetDataToNode(HillslopeConfig.alfroot, GetTextBoxValue(HillslopeConfig.alfroot));
            XmlData.SetDataToNode(HillslopeConfig.woleaf, GetTextBoxValue(HillslopeConfig.woleaf));
            XmlData.SetDataToNode(HillslopeConfig.czrl, GetTextBoxValue(HillslopeConfig.czrl));
            XmlData.SetDataToNode(HillslopeConfig.czov, GetTextBoxValue(HillslopeConfig.czov));
            XmlData.SetDataToNode(HillslopeConfig.bwrl0, GetTextBoxValue(HillslopeConfig.bwrl0));
            XmlData.SetDataToNode(HillslopeConfig.srinit, GetTextBoxValue(HillslopeConfig.srinit));
            XmlData.SetDataToNode(HillslopeConfig.DENSG, GetTextBoxValue(HillslopeConfig.DENSG));
            XmlData.SetDataToNode(HillslopeConfig.albedos0, GetTextBoxValue(HillslopeConfig.albedos0));
            XmlData.SetDataToNode(HillslopeConfig.albedow0, GetTextBoxValue(HillslopeConfig.albedow0));
            XmlData.SetDataToNode(HillslopeConfig.roughs0, GetTextBoxValue(HillslopeConfig.roughs0));
            XmlData.SetDataToNode(HillslopeConfig.roughw0, GetTextBoxValue(HillslopeConfig.roughw0));
            XmlData.SetDataToNode(HillslopeConfig.vlai0, GetTextBoxValue(HillslopeConfig.vlai0));
            XmlData.SetDataToNode(HillslopeConfig.CG, GetTextBoxValue(HillslopeConfig.CG));

            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Jan, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Jan));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Feb, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Feb));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Mar, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Mar));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Apr, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Apr));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.May, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.May));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Jun, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Jun));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Jul, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Jul));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Aug, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Aug));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Sep, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Sep));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Oct, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Oct));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Nov, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Nov));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_albedo + "/"+Months.Dec, GetTextBoxValue(HillslopeConfig.RMXMN_albedo + Months.Dec));

            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Jan, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Jan));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Feb, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Feb));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Mar, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Mar));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Apr, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Apr));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.May, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.May));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Jun, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Jun));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Jul, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Jul));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Aug, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Aug));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Sep, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Sep));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Oct, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Oct));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Nov, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Nov));
            XmlData.SetDataToNode(HillslopeConfig.RMXMN_z0 + "/" + Months.Dec, GetTextBoxValue(HillslopeConfig.RMXMN_z0 + Months.Dec));

            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Jan, GetTextBoxValue(HillslopeConfig.adjprec + Months.Jan));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Feb, GetTextBoxValue(HillslopeConfig.adjprec + Months.Feb));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Mar, GetTextBoxValue(HillslopeConfig.adjprec + Months.Mar));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Apr, GetTextBoxValue(HillslopeConfig.adjprec + Months.Apr));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.May, GetTextBoxValue(HillslopeConfig.adjprec + Months.May));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Jun, GetTextBoxValue(HillslopeConfig.adjprec + Months.Jun));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Jul, GetTextBoxValue(HillslopeConfig.adjprec + Months.Jul));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Aug, GetTextBoxValue(HillslopeConfig.adjprec + Months.Aug));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Sep, GetTextBoxValue(HillslopeConfig.adjprec + Months.Sep));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Oct, GetTextBoxValue(HillslopeConfig.adjprec + Months.Oct));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Nov, GetTextBoxValue(HillslopeConfig.adjprec + Months.Nov));
            XmlData.SetDataToNode(HillslopeConfig.adjprec + "/" + Months.Dec, GetTextBoxValue(HillslopeConfig.adjprec + Months.Dec));

            //Routing Parameters (Global Params + Reach Params)
            // Global Params

            XmlDataGlobals.SetDataToNode(GlobalConfig.NREACH,GetTextBoxValue(GlobalConfig.NREACH));
            XmlDataGlobals.SetDataToNode(GlobalConfig.G, GetTextBoxValue(GlobalConfig.G));
            XmlDataGlobals.SetDataToNode(GlobalConfig.TLAST, GetTextBoxValue(GlobalConfig.TLAST));
            XmlDataGlobals.SetDataToNode(GlobalConfig.OUTINT, GetTextBoxValue(GlobalConfig.OUTINT));
            XmlDataGlobals.SetDataToNode(GlobalConfig.S_OUTLET, GetTextBoxValue(GlobalConfig.S_OUTLET));
            XmlDataGlobals.SetDataToNode(GlobalConfig.TH_IC, GetTextBoxValue(GlobalConfig.TH_IC));
            XmlDataGlobals.SetDataToNode(GlobalConfig.KAPPA, GetTextBoxValue(GlobalConfig.KAPPA));
            XmlDataGlobals.SetDataToNode(GlobalConfig.LOW_D, GetTextBoxValue(GlobalConfig.LOW_D));
            XmlDataGlobals.SetDataToNode(GlobalConfig.LOW_S, GetTextBoxValue(GlobalConfig.LOW_S));
            XmlDataGlobals.SetDataToNode(GlobalConfig.L_out, GetTextBoxValue(GlobalConfig.L_out));
            XmlDataGlobals.SetDataToNode(GlobalConfig.S0MIN, GetTextBoxValue(GlobalConfig.S0MIN));
            XmlDataGlobals.SetDataToNode(GlobalConfig.S0MAX, GetTextBoxValue(GlobalConfig.S0MAX));
            XmlDataGlobals.SetDataToNode(GlobalConfig.R_INTAKE, GetTextBoxValue(GlobalConfig.R_INTAKE));
            XmlDataGlobals.SetDataToNode(GlobalConfig.Y_GW0, GetTextBoxValue(GlobalConfig.Y_GW0));
            XmlDataGlobals.SetDataToNode(GlobalConfig.LG_EXCH, GetTextBoxValue(GlobalConfig.LG_EXCH));
            XmlDataGlobals.SetDataToNode(GlobalConfig.F_SFGW, GetTextBoxValue(GlobalConfig.F_SFGW));
            XmlDataGlobals.SetDataToNode(GlobalConfig.F_CMN, GetTextBoxValue(GlobalConfig.F_CMN));
            XmlDataGlobals.SetDataToNode(GlobalConfig.F_WIDTH, GetTextBoxValue(GlobalConfig.F_WIDTH));
            XmlDataGlobals.SetDataToNode(GlobalConfig.F_YIELD, GetTextBoxValue(GlobalConfig.F_YIELD));
            XmlDataGlobals.SetDataToNode(GlobalConfig.F_TRNS, GetTextBoxValue(GlobalConfig.F_TRNS));
            XmlDataGlobals.SetDataToNode(GlobalConfig.F_LEAK, GetTextBoxValue(GlobalConfig.F_LEAK));

            //Reach Params 
            SaveDataToXml();
        }

        public void LoadDefaultParams()
        {
            //Hillslope Parameters
            SetValueForTextBox(HillslopeConfig.NXhs0, Default_XmlData.GetDataFromNode(HillslopeConfig.NXhs0, "data"));
            SetValueForTextBox(HillslopeConfig.NXrl0, Default_XmlData.GetDataFromNode(HillslopeConfig.NXrl0, "data"));
            SetValueForTextBox(HillslopeConfig.NThs, Default_XmlData.GetDataFromNode(HillslopeConfig.NThs, "data"));
            SetValueForTextBox(HillslopeConfig.NTrl, Default_XmlData.GetDataFromNode(HillslopeConfig.NTrl, "data"));
            SetValueForTextBox(HillslopeConfig.alfKs, Default_XmlData.GetDataFromNode(HillslopeConfig.alfKs, "data"));
            SetValueForTextBox(HillslopeConfig.alfsdp, Default_XmlData.GetDataFromNode(HillslopeConfig.alfsdp, "data"));
            SetValueForTextBox(HillslopeConfig.DEPTH_SLAB, Default_XmlData.GetDataFromNode("DEPTHSLAB", "data"));
            SetValueForTextBox(HillslopeConfig.alfroot, Default_XmlData.GetDataFromNode(HillslopeConfig.alfroot, "data"));
            SetValueForTextBox(HillslopeConfig.woleaf, Default_XmlData.GetDataFromNode(HillslopeConfig.woleaf, "data"));
            SetValueForTextBox(HillslopeConfig.czrl, Default_XmlData.GetDataFromNode(HillslopeConfig.czrl, "data"));
            SetValueForTextBox(HillslopeConfig.czov, Default_XmlData.GetDataFromNode(HillslopeConfig.czov, "data"));
            SetValueForTextBox(HillslopeConfig.bwrl0, Default_XmlData.GetDataFromNode(HillslopeConfig.bwrl0, "data"));
            SetValueForTextBox(HillslopeConfig.srinit, Default_XmlData.GetDataFromNode(HillslopeConfig.srinit, "data"));
            SetValueForTextBox(HillslopeConfig.DENSG, Default_XmlData.GetDataFromNode(HillslopeConfig.DENSG, "data"));
            SetValueForTextBox(HillslopeConfig.albedos0, Default_XmlData.GetDataFromNode(HillslopeConfig.albedos0, "data"));
            SetValueForTextBox(HillslopeConfig.albedow0, Default_XmlData.GetDataFromNode(HillslopeConfig.albedow0, "data"));
            SetValueForTextBox(HillslopeConfig.roughs0, Default_XmlData.GetDataFromNode(HillslopeConfig.roughs0, "data"));
            SetValueForTextBox(HillslopeConfig.roughw0, Default_XmlData.GetDataFromNode(HillslopeConfig.roughw0, "data"));
            SetValueForTextBox(HillslopeConfig.vlai0, Default_XmlData.GetDataFromNode(HillslopeConfig.vlai0, "data"));
            SetValueForTextBox(HillslopeConfig.CG, Default_XmlData.GetDataFromNode(HillslopeConfig.CG, "data"));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Jan, Default_XmlData.GetDataFromNode(Months.Jan, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Feb, Default_XmlData.GetDataFromNode(Months.Feb, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Mar, Default_XmlData.GetDataFromNode(Months.Mar, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Apr, Default_XmlData.GetDataFromNode(Months.Apr, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.May, Default_XmlData.GetDataFromNode(Months.May, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Jun, Default_XmlData.GetDataFromNode(Months.Jun, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Jul, Default_XmlData.GetDataFromNode(Months.Jul, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Aug, Default_XmlData.GetDataFromNode(Months.Aug, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Sep, Default_XmlData.GetDataFromNode(Months.Sep, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Oct, Default_XmlData.GetDataFromNode(Months.Oct, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Nov, Default_XmlData.GetDataFromNode(Months.Nov, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Dec, Default_XmlData.GetDataFromNode(Months.Dec, "data/" + HillslopeConfig.RMXMN_albedo));

            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Jan, Default_XmlData.GetDataFromNode(Months.Jan, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Feb, Default_XmlData.GetDataFromNode(Months.Feb, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Mar, Default_XmlData.GetDataFromNode(Months.Mar, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Apr, Default_XmlData.GetDataFromNode(Months.Apr, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.May, Default_XmlData.GetDataFromNode(Months.May, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Jun, Default_XmlData.GetDataFromNode(Months.Jun, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Jul, Default_XmlData.GetDataFromNode(Months.Jul, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Aug, Default_XmlData.GetDataFromNode(Months.Aug, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Sep, Default_XmlData.GetDataFromNode(Months.Sep, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Oct, Default_XmlData.GetDataFromNode(Months.Oct, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Nov, Default_XmlData.GetDataFromNode(Months.Nov, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Dec, Default_XmlData.GetDataFromNode(Months.Dec, "data/" + HillslopeConfig.RMXMN_z0));

            SetValueForTextBox(HillslopeConfig.adjprec + Months.Jan, Default_XmlData.GetDataFromNode(Months.Jan, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Feb, Default_XmlData.GetDataFromNode(Months.Feb, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Mar, Default_XmlData.GetDataFromNode(Months.Mar, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Apr, Default_XmlData.GetDataFromNode(Months.Apr, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.May, Default_XmlData.GetDataFromNode(Months.May, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Jun, Default_XmlData.GetDataFromNode(Months.Jun, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Jul, Default_XmlData.GetDataFromNode(Months.Jul, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Aug, Default_XmlData.GetDataFromNode(Months.Aug, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Sep, Default_XmlData.GetDataFromNode(Months.Sep, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Oct, Default_XmlData.GetDataFromNode(Months.Oct, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Nov, Default_XmlData.GetDataFromNode(Months.Nov, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Dec, Default_XmlData.GetDataFromNode(Months.Dec, "data/" + HillslopeConfig.adjprec));

            //Routing Parameters (Global Params + Reach Params)
            // Global Params

            SetValueForTextBox(GlobalConfig.NREACH, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.NREACH, "data"));
            SetValueForTextBox(GlobalConfig.G, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.G, "data"));
            SetValueForTextBox(GlobalConfig.TLAST, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.TLAST, "data"));
            SetValueForTextBox(GlobalConfig.OUTINT, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.OUTINT, "data"));
            SetValueForTextBox(GlobalConfig.S_OUTLET, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.S_OUTLET, "data"));
            SetValueForTextBox(GlobalConfig.TH_IC, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.TH_IC, "data"));
            SetValueForTextBox(GlobalConfig.KAPPA, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.KAPPA, "data"));
            SetValueForTextBox(GlobalConfig.LOW_D, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.LOW_D, "data"));
            SetValueForTextBox(GlobalConfig.LOW_S, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.LOW_S, "data"));
            SetValueForTextBox(GlobalConfig.L_out, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.L_out, "data"));
            SetValueForTextBox(GlobalConfig.S0MIN, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.S0MIN, "data"));
            SetValueForTextBox(GlobalConfig.S0MAX, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.S0MAX, "data"));
            SetValueForTextBox(GlobalConfig.R_INTAKE, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.R_INTAKE, "data"));
            SetValueForTextBox(GlobalConfig.Y_GW0, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.Y_GW0, "data"));
            SetValueForTextBox(GlobalConfig.LG_EXCH, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.LG_EXCH, "data"));
            SetValueForTextBox(GlobalConfig.F_SFGW, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.F_SFGW, "data"));
            SetValueForTextBox(GlobalConfig.F_CMN, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.F_CMN, "data"));
            SetValueForTextBox(GlobalConfig.F_WIDTH, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.F_WIDTH, "data"));
            SetValueForTextBox(GlobalConfig.F_YIELD, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.F_YIELD, "data"));
            SetValueForTextBox(GlobalConfig.F_TRNS, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.F_TRNS, "data"));
            SetValueForTextBox(GlobalConfig.F_LEAK, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.F_LEAK, "data"));
            SetValueForTextBox(GlobalConfig.NREACH, Default_XmlDataGlobals.GetDataFromNode(GlobalConfig.NREACH, "data"));

            LoadDataXmlDefault();
        }

        public void SetDefaultValues()
        {
            //Hillslope Parameters
            SetValueForTextBox(HillslopeConfig.NXhs0, XmlData.GetDataFromNode(HillslopeConfig.NXhs0, "data"));
            SetValueForTextBox(HillslopeConfig.NXrl0, XmlData.GetDataFromNode(HillslopeConfig.NXrl0, "data"));
            SetValueForTextBox(HillslopeConfig.NThs, XmlData.GetDataFromNode(HillslopeConfig.NThs, "data"));
            SetValueForTextBox(HillslopeConfig.NTrl, XmlData.GetDataFromNode(HillslopeConfig.NTrl, "data"));
            SetValueForTextBox(HillslopeConfig.alfKs, XmlData.GetDataFromNode(HillslopeConfig.alfKs, "data"));
            SetValueForTextBox(HillslopeConfig.alfsdp, XmlData.GetDataFromNode(HillslopeConfig.alfsdp, "data"));
            SetValueForTextBox(HillslopeConfig.DEPTH_SLAB, XmlData.GetDataFromNode("DEPTHSLAB", "data"));
            SetValueForTextBox(HillslopeConfig.alfroot, XmlData.GetDataFromNode(HillslopeConfig.alfroot, "data"));
            SetValueForTextBox(HillslopeConfig.woleaf, XmlData.GetDataFromNode(HillslopeConfig.woleaf, "data"));
            SetValueForTextBox(HillslopeConfig.czrl, XmlData.GetDataFromNode(HillslopeConfig.czrl, "data"));
            SetValueForTextBox(HillslopeConfig.czov, XmlData.GetDataFromNode(HillslopeConfig.czov, "data"));
            SetValueForTextBox(HillslopeConfig.bwrl0, XmlData.GetDataFromNode(HillslopeConfig.bwrl0, "data"));
            SetValueForTextBox(HillslopeConfig.srinit, XmlData.GetDataFromNode(HillslopeConfig.srinit, "data"));
            SetValueForTextBox(HillslopeConfig.DENSG, XmlData.GetDataFromNode(HillslopeConfig.DENSG, "data"));
            SetValueForTextBox(HillslopeConfig.albedos0, XmlData.GetDataFromNode(HillslopeConfig.albedos0, "data"));
            SetValueForTextBox(HillslopeConfig.albedow0, XmlData.GetDataFromNode(HillslopeConfig.albedow0, "data"));
            SetValueForTextBox(HillslopeConfig.roughs0, XmlData.GetDataFromNode(HillslopeConfig.roughs0, "data"));
            SetValueForTextBox(HillslopeConfig.roughw0, XmlData.GetDataFromNode(HillslopeConfig.roughw0, "data"));
            SetValueForTextBox(HillslopeConfig.vlai0, XmlData.GetDataFromNode(HillslopeConfig.vlai0, "data"));
            SetValueForTextBox(HillslopeConfig.CG, XmlData.GetDataFromNode(HillslopeConfig.CG, "data"));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Jan, XmlData.GetDataFromNode(Months.Jan, "data/"+ HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Feb, XmlData.GetDataFromNode(Months.Feb, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Mar, XmlData.GetDataFromNode(Months.Mar, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Apr, XmlData.GetDataFromNode(Months.Apr, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.May, XmlData.GetDataFromNode(Months.May, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Jun, XmlData.GetDataFromNode(Months.Jun, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Jul, XmlData.GetDataFromNode(Months.Jul, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Aug, XmlData.GetDataFromNode(Months.Aug, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Sep, XmlData.GetDataFromNode(Months.Sep, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Oct, XmlData.GetDataFromNode(Months.Oct, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Nov, XmlData.GetDataFromNode(Months.Nov, "data/" + HillslopeConfig.RMXMN_albedo));
            SetValueForTextBox(HillslopeConfig.RMXMN_albedo + Months.Dec, XmlData.GetDataFromNode(Months.Dec, "data/" + HillslopeConfig.RMXMN_albedo));

            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Jan, XmlData.GetDataFromNode(Months.Jan, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Feb, XmlData.GetDataFromNode(Months.Feb, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Mar, XmlData.GetDataFromNode(Months.Mar, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Apr, XmlData.GetDataFromNode(Months.Apr, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.May, XmlData.GetDataFromNode(Months.May, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Jun, XmlData.GetDataFromNode(Months.Jun, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Jul, XmlData.GetDataFromNode(Months.Jul, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Aug, XmlData.GetDataFromNode(Months.Aug, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Sep, XmlData.GetDataFromNode(Months.Sep, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Oct, XmlData.GetDataFromNode(Months.Oct, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Nov, XmlData.GetDataFromNode(Months.Nov, "data/" + HillslopeConfig.RMXMN_z0));
            SetValueForTextBox(HillslopeConfig.RMXMN_z0 + Months.Dec, XmlData.GetDataFromNode(Months.Dec, "data/" + HillslopeConfig.RMXMN_z0));

            SetValueForTextBox(HillslopeConfig.adjprec + Months.Jan, XmlData.GetDataFromNode(Months.Jan, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Feb, XmlData.GetDataFromNode(Months.Feb, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Mar, XmlData.GetDataFromNode(Months.Mar, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Apr, XmlData.GetDataFromNode(Months.Apr, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.May, XmlData.GetDataFromNode(Months.May, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Jun, XmlData.GetDataFromNode(Months.Jun, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Jul, XmlData.GetDataFromNode(Months.Jul, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Aug, XmlData.GetDataFromNode(Months.Aug, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Sep, XmlData.GetDataFromNode(Months.Sep, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Oct, XmlData.GetDataFromNode(Months.Oct, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Nov, XmlData.GetDataFromNode(Months.Nov, "data/" + HillslopeConfig.adjprec));
            SetValueForTextBox(HillslopeConfig.adjprec + Months.Dec, XmlData.GetDataFromNode(Months.Dec, "data/" + HillslopeConfig.adjprec));

            //Routing Parameters (Global Params + Reach Params)
            // Global Params

            SetValueForTextBox(GlobalConfig.NREACH, XmlDataGlobals.GetDataFromNode(GlobalConfig.NREACH, "data"));
            SetValueForTextBox(GlobalConfig.G, XmlDataGlobals.GetDataFromNode(GlobalConfig.G, "data"));
            SetValueForTextBox(GlobalConfig.TLAST, XmlDataGlobals.GetDataFromNode(GlobalConfig.TLAST, "data"));
            SetValueForTextBox(GlobalConfig.OUTINT, XmlDataGlobals.GetDataFromNode(GlobalConfig.OUTINT, "data"));
            SetValueForTextBox(GlobalConfig.S_OUTLET, XmlDataGlobals.GetDataFromNode(GlobalConfig.S_OUTLET, "data"));
            SetValueForTextBox(GlobalConfig.TH_IC, XmlDataGlobals.GetDataFromNode(GlobalConfig.TH_IC, "data"));
            SetValueForTextBox(GlobalConfig.KAPPA, XmlDataGlobals.GetDataFromNode(GlobalConfig.KAPPA, "data"));
            SetValueForTextBox(GlobalConfig.LOW_D, XmlDataGlobals.GetDataFromNode(GlobalConfig.LOW_D, "data"));
            SetValueForTextBox(GlobalConfig.LOW_S, XmlDataGlobals.GetDataFromNode(GlobalConfig.LOW_S, "data"));
            SetValueForTextBox(GlobalConfig.L_out, XmlDataGlobals.GetDataFromNode(GlobalConfig.L_out, "data"));
            SetValueForTextBox(GlobalConfig.S0MIN, XmlDataGlobals.GetDataFromNode(GlobalConfig.S0MIN, "data"));
            SetValueForTextBox(GlobalConfig.S0MAX, XmlDataGlobals.GetDataFromNode(GlobalConfig.S0MAX, "data"));
            SetValueForTextBox(GlobalConfig.R_INTAKE, XmlDataGlobals.GetDataFromNode(GlobalConfig.R_INTAKE, "data"));
            SetValueForTextBox(GlobalConfig.Y_GW0, XmlDataGlobals.GetDataFromNode(GlobalConfig.Y_GW0, "data"));
            SetValueForTextBox(GlobalConfig.LG_EXCH, XmlDataGlobals.GetDataFromNode(GlobalConfig.LG_EXCH, "data"));
            SetValueForTextBox(GlobalConfig.F_SFGW, XmlDataGlobals.GetDataFromNode(GlobalConfig.F_SFGW, "data"));
            SetValueForTextBox(GlobalConfig.F_CMN, XmlDataGlobals.GetDataFromNode(GlobalConfig.F_CMN, "data"));
            SetValueForTextBox(GlobalConfig.F_WIDTH, XmlDataGlobals.GetDataFromNode(GlobalConfig.F_WIDTH, "data"));
            SetValueForTextBox(GlobalConfig.F_YIELD, XmlDataGlobals.GetDataFromNode(GlobalConfig.F_YIELD, "data"));
            SetValueForTextBox(GlobalConfig.F_TRNS, XmlDataGlobals.GetDataFromNode(GlobalConfig.F_TRNS, "data"));
            SetValueForTextBox(GlobalConfig.F_LEAK, XmlDataGlobals.GetDataFromNode(GlobalConfig.F_LEAK, "data"));
            SetValueForTextBox(GlobalConfig.NREACH, XmlDataGlobals.GetDataFromNode(GlobalConfig.NREACH, "data"));

            LoadDataFromXml();
        }

        private DataGridView GetReachParamsGridData()
        {
            DataGridView dataGridView1 = (DataGridView)thisForm.Controls.Find("dataGridView1", true).FirstOrDefault();
            return dataGridView1;
        }

        private DataSet CreateDataSetFromDataGridView()
        {
            DataTable dt = (DataTable)GetReachParamsGridData().DataSource;
            var DataCopy = dt.Copy();
            DataSet ds = new DataSet();
            ds.Tables.Add(DataCopy);

            return ds;
        }

        private void SaveDataToXml()
        {
            var Data = CreateDataSetFromDataGridView();
            Data.WriteXml(WEHY.Business.Initialize.ProjectDirectory.Directory + Directory.Project_ReachParaFile);
        }

        private void LoadDataFromXml()
        {
            DataSet data = new DataSet();
            data.ReadXml(WEHY.Business.Initialize.ProjectDirectory.Directory + Directory.Project_ReachParaFile);
            GetReachParamsGridData().DataSource = data.Tables["ReachParams"];
        }

        private void LoadDataXmlDefault()
        {
            DataSet data = new DataSet();
            data.ReadXml(RootDirectory.Directory + Directory.ReachPara);
            GetReachParamsGridData().DataSource = data.Tables["ReachParams"];
        }

        private void SetValueForTextBox(string textBoxName, string value)
        {
            var textBox = GetTextBoxByName(textBoxName);
            textBox.Text = value;
        }

        private string GetTextBoxValue(string textBoxName)
        {
            var textBox = GetTextBoxByName(textBoxName);
            return textBox.Text;
        }

        private TextBox GetTextBoxByName(string textBoxName)
        {
            TextBox text = (TextBox)thisForm.Controls.Find(textBoxName, true).FirstOrDefault();
            return text;
        }

        public void RenderWEHYFile()
        {
            RenderFile.RenderWEHYControl();
            RenderFile.RenderParaChay();
        }

        public string getConfigState()
        {
            string node = "use_default";
            var data = XmlData.GetDataFromNode(node, "data");
            return data;
        }

        public void setConfigState(string IsDefault)
        {
            string node = "use_default";
            XmlData.SetDataToNode(node, IsDefault);
        }

        public void DeleteFile()
        {
            RenderFile.DeleteWEHYControl();
            RenderFile.DeleteParaChay();
        }
    }
}
