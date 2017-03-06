using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WEHY.Views.Run
{
    public partial class RunProcess : Form
    {
        Controllers.RunProcessController controller;
        public RunProcess()
        {
            InitializeComponent();
            controller = new Controllers.RunProcessController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                controller.RunWEHYSimulation();
                MessageBox.Show("Running File !");
        }
    }
}
