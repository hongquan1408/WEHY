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

namespace WEHY.Views.File
{
    public partial class NewProject : Form
    {
        public string ProjectDirectory{get;set;}
        public string ProjectFullPath { get; set; }
        public string ProjectName{get;set;}

        NewProjectController controller;
        Main frmForm;
        public NewProject(Main frmMain)
        {
           
            InitializeComponent();
            frmForm = frmMain;
            ProjectDirectory = "";
            ProjectName = "";
            controller = new NewProjectController(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenFolder = new FolderBrowserDialog();
            OpenFolder.ShowDialog();
            textBox2.Text = OpenFolder.SelectedPath;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Controllers.Common.RecentProjectCommon recentProject = new Controllers.Common.RecentProjectCommon();

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                this.ProjectDirectory = textBox2.Text;
                this.ProjectName = textBox1.Text;
                this.controller.CreateProject(ProjectDirectory, ProjectName);
                ProjectFullPath = System.IO.Path.Combine(ProjectDirectory, ProjectName);
                string path = System.IO.Path.Combine(System.IO.Path.Combine(ProjectDirectory, ProjectName), ProjectName + ".wehy");
                recentProject.setRecentlyProjectPath(path);
                frmForm.OutputFolder = ProjectFullPath;

                this.Close();
            }
            else
                MessageBox.Show("Please Input Project name or Directory" ,"Missing name or directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void NewProject_Load(object sender, EventArgs e)
        {

        }
    }
}
