using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Config;
using WEHY.Config.RoutingConfig;
using WEHY.Controllers;
using System.Windows.Forms;

namespace WEHY.Views.Config
{
    public partial class EditConfig : Form
    {
        EditConfigController controller;
        string _true;
        string _false;
        public EditConfig()
        {
            _true = "true";
            _false = "false";
            InitializeComponent();
            changeName();
            controller = new EditConfigController(this);
            controller.SetDefaultValues();
            controller.RenderWEHYFile();
            CheckConfigState();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                controller.SetDefaultValues();
                UnlockComponent();
            }
            else
            {
                controller.LoadDefaultParams();
                LockComponent();
            }
        }

        private void UnlockComponent()
        {
            UnlockTextBoxs();
            UnlockTextBoxsTab2();
            UnlockDataGridView();
        }

        private void LockComponent()
        {
            LockTextBoxs();
            LockTextBoxsTab2();
            lockDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string state = checkBox2.Checked ? _true : _false;
            controller.setConfigState(state);
            controller.SaveConfig();
            controller.DeleteFile();
            controller.RenderWEHYFile();
            MessageBox.Show("Save Completed !");
            this.Close();
        }

        private void UnlockDataGridView()
        {
            dataGridView1.ReadOnly = false;
        }

        private void lockDataGridView()
        {
            dataGridView1.ReadOnly = true;
        }

        private void UnlockTextBoxsTab2()
        {
            foreach (Control X in groupBox1.Controls)
            {
                TextBox tb = X as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = false;
                }
            }
        }


        private void UnlockTextBoxs()
        {
            foreach (Control X in tabPage1.Controls)
            {
                TextBox tb = X as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = false;
                }
            }

            foreach (Control X in panel1.Controls)
            {
                TextBox tb = X as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = false;
                }
            }
        }

        private void LockTextBoxsTab2()
        {
            foreach (Control X in groupBox1.Controls)
            {
                TextBox tb = X as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = true;
                }
            }
        }

        private void LockTextBoxs()
        {
            foreach (Control X in tabPage1.Controls)
            {
                TextBox tb = X as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = true;
                }
            }

            foreach (Control X in panel1.Controls)
            {
                TextBox tb = X as TextBox;
                if (tb != null)
                {
                    tb.ReadOnly = true;
                }
            }
        }

        private void CheckConfigState()
        {
            string state = controller.getConfigState();
            if (state == _true)
            {
                checkBox2.Checked = true;
            }
            else
                checkBox2.Checked = false;
        }

        private void changeName()
        {
            this.textBox16.Name = HillslopeConfig.CG;
            this.textBox17.Name = HillslopeConfig.vlai0;
            this.textBox18.Name = HillslopeConfig.roughw0;
            this.textBox19.Name = HillslopeConfig.roughs0;
            this.textBox20.Name = HillslopeConfig.albedow0;
            this.textBox21.Name = HillslopeConfig.albedos0;
            this.textBox8.Name = HillslopeConfig.DENSG;
            this.textBox9.Name = HillslopeConfig.srinit;
            this.textBox10.Name = HillslopeConfig.bwrl0;
            this.textBox11.Name = HillslopeConfig.czov;
            this.textBox12.Name = HillslopeConfig.czrl;
            this.textBox13.Name = HillslopeConfig.woleaf;
            this.textBox14.Name = HillslopeConfig.alfroot;
            this.textBox7.Name = HillslopeConfig.DEPTH_SLAB;
            this.textBox6.Name = HillslopeConfig.alfsdp;
            this.textBox5.Name = HillslopeConfig.alfKs;
            this.textBox4.Name = HillslopeConfig.NTrl;
            this.textBox3.Name = HillslopeConfig.NThs;
            this.textBox2.Name = HillslopeConfig.NXrl0;
            this.textbox1.Name = HillslopeConfig.NXhs0;

            this.textBox45.Name = HillslopeConfig.adjprec + Months.Dec;
            this.textBox46.Name = HillslopeConfig.adjprec + Months.Nov;
            this.textBox47.Name = HillslopeConfig.adjprec + Months.Oct;
            this.textBox48.Name = HillslopeConfig.adjprec + Months.Sep;
            this.textBox49.Name = HillslopeConfig.adjprec + Months.Aug;
            this.textBox50.Name = HillslopeConfig.adjprec + Months.Jul;
            this.textBox51.Name = HillslopeConfig.adjprec + Months.Jun;
            this.textBox52.Name = HillslopeConfig.adjprec + Months.May;
            this.textBox53.Name = HillslopeConfig.adjprec + Months.Apr;
            this.textBox54.Name = HillslopeConfig.adjprec + Months.Mar;
            this.textBox55.Name = HillslopeConfig.adjprec + Months.Feb;
            this.textBox56.Name = HillslopeConfig.adjprec + Months.Jan;
            this.textBox33.Name = HillslopeConfig.RMXMN_z0 + Months.Dec;
            this.textBox34.Name = HillslopeConfig.RMXMN_z0 + Months.Nov;
            this.textBox35.Name = HillslopeConfig.RMXMN_z0 + Months.Oct;
            this.textBox36.Name = HillslopeConfig.RMXMN_z0 + Months.Sep;
            this.textBox37.Name = HillslopeConfig.RMXMN_z0 + Months.Aug;
            this.textBox38.Name = HillslopeConfig.RMXMN_z0 + Months.Jul;
            this.textBox39.Name = HillslopeConfig.RMXMN_z0 + Months.Jun;
            this.textBox40.Name = HillslopeConfig.RMXMN_z0 + Months.May;
            this.textBox41.Name = HillslopeConfig.RMXMN_z0 + Months.Apr;
            this.textBox42.Name = HillslopeConfig.RMXMN_z0 + Months.Mar;
            this.textBox43.Name = HillslopeConfig.RMXMN_z0 + Months.Feb;
            this.textBox44.Name = HillslopeConfig.RMXMN_z0 + Months.Jan;
            this.textBox27.Name = HillslopeConfig.RMXMN_albedo + Months.Dec;
            this.textBox28.Name = HillslopeConfig.RMXMN_albedo + Months.Nov;
            this.textBox29.Name = HillslopeConfig.RMXMN_albedo + Months.Oct;
            this.textBox30.Name = HillslopeConfig.RMXMN_albedo + Months.Sep;
            this.textBox31.Name = HillslopeConfig.RMXMN_albedo + Months.Aug;
            this.textBox32.Name = HillslopeConfig.RMXMN_albedo + Months.Jul;
            this.textBox26.Name = HillslopeConfig.RMXMN_albedo + Months.Jun;
            this.textBox25.Name = HillslopeConfig.RMXMN_albedo + Months.May;
            this.textBox24.Name = HillslopeConfig.RMXMN_albedo + Months.Apr;
            this.textBox23.Name = HillslopeConfig.RMXMN_albedo + Months.Mar;
            this.textBox22.Name = HillslopeConfig.RMXMN_albedo + Months.Feb;
            this.textBox15.Name = HillslopeConfig.RMXMN_albedo + Months.Jan;

            this.textBox77.Name = GlobalConfig.F_LEAK;
            this.textBox67.Name = GlobalConfig.F_TRNS;
            this.textBox68.Name = GlobalConfig.F_YIELD;
            this.textBox69.Name = GlobalConfig.F_WIDTH;
            this.textBox70.Name = GlobalConfig.F_CMN;
            this.textBox71.Name = GlobalConfig.F_SFGW;
            this.textBox72.Name = GlobalConfig.LG_EXCH;
            this.textBox73.Name = GlobalConfig.Y_GW0;
            this.textBox74.Name = GlobalConfig.R_INTAKE;
            this.textBox75.Name = GlobalConfig.S0MAX;
            this.textBox76.Name = GlobalConfig.S0MIN;
            this.textBox62.Name = GlobalConfig.L_out;
            this.textBox63.Name = GlobalConfig.LOW_S;
            this.textBox64.Name = GlobalConfig.LOW_D;
            this.textBox65.Name = GlobalConfig.KAPPA;
            this.textBox66.Name = GlobalConfig.TH_IC;
            this.textBox61.Name = GlobalConfig.S_OUTLET;
            this.textBox60.Name = GlobalConfig.OUTINT;
            this.textBox59.Name = GlobalConfig.TLAST;
            this.textBox58.Name = GlobalConfig.G;
            this.textBox57.Name = GlobalConfig.NREACH;
        }

        
    }
}
