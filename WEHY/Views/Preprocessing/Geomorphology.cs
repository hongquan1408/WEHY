using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEHY.Controllers;
using System.Windows.Forms;

namespace WEHY.Views.Preprocessing
{
    public partial class Geomorphology : Form
    {
        public Geomorphology()
        {
            InitializeComponent();
        }
        
        //Main frmForm;
        private void Geomorphology_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("0");
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox8.Text = "100";
                comboBox1.Text = "0";
                textBox9.Text = "3";
                textBox10.Text = "2";
                textBox11.Text = "150";
                textBox12.Text = "1";
                textBox13.Text = "30";
                textBox8.Enabled = false;
                comboBox1.Enabled = false;
                textBox10.Enabled = false;
                textBox9.Enabled = false;
                textBox11.Enabled = false;
                textBox12.Enabled = false;
                textBox13.Enabled = false;
            }
            else
            {
                textBox8.Enabled = true;
                comboBox1.Enabled = true;
                textBox10.Enabled = true;
                textBox9.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                textBox13.Enabled = true;
            }
        }
    }
}
