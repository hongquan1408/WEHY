using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WEHY.Views.File;
using WEHY.Views.Config;
using WEHY.Views.Run;
using WEHY.Business.Initialize;
using System.IO;

namespace WEHY.Views
{
    public partial class Main : Form
    {
        Controllers.MainController controller;
        Controllers.RunProcessController runController;
        public string OutputFolder { get; set; }
        public Main()
        {
            InitializeComponent();
            controller = new Controllers.MainController(this);
            runController = new Controllers.RunProcessController();
            ProjectDirectory.Change += CheckExistProject;
            ProjectDirectory.Directory = "";
            hydroOutToolStripMenuItem.Enabled = false;
            inFlowToolStripMenuItem.Enabled = false;
            hillFlowToolStripMenuItem.Enabled = false;

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject NewProjectForm = new NewProject(this);
            NewProjectForm.Show();
        }

        private void parameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditConfig EditConfigForm = new EditConfig();
            EditConfigForm.Show();
        }

        private void parameterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            RunConfigForm();
        }

        private void newProjectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NewProject NewProjectForm = new NewProject(this);
            NewProjectForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckFile())
                runController.RunAllProcess();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunConfigForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.ShowDialog();
            if (OpenFile.FileName != string.Empty)
            {
                controller.CopyFile(OpenFile.FileName);
            }
            else
                MessageBox.Show("Please Choose a file");
            changeTreeView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.ShowDialog();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog Opener = new OpenFileDialog();
            Opener.ShowDialog();
            Controllers.Common.RecentProjectCommon recentProject = new Controllers.Common.RecentProjectCommon();
            string filename = System.IO.Path.GetFileName(Opener.FileName);
            if (filename.Contains(".wehy"))
            {
                ProjectDirectory.Directory = System.IO.Path.GetDirectoryName(Opener.FileName);
                ProjectName.Name = System.IO.Path.GetFileName(Opener.FileName);
                recentProject.setRecentlyProjectPath(System.IO.Path.Combine(ProjectDirectory.Directory, ProjectName.Name));
                OutputFolder = ProjectDirectory.Directory;
                CheckExistOutputFile(OutputFolder);
                MessageBox.Show("Open Succeed Project " + filename);
            }
            else
                MessageBox.Show("Please Choose a Project !");
        }
        /// <summary>
        /// Check Exist Folder
        /// </summary>
        /// <param name="Folder"></param>
        /// <returns></returns>
        public bool CheckExistOutputFile(string OutputFolder)
        {
            string outputHydro = @"" + OutputFolder + "\\outputs\\R_hydro_out.csv";
            string outputInflow = @"" + OutputFolder + "\\outputs\\R_inflow.csv";
            string outputHillflow = @"" + OutputFolder + "\\outputs\\HILLflow.csv";
            if (System.IO.File.Exists(outputHydro))
            {
                hydroOutToolStripMenuItem.Enabled = true;
            }
            if (System.IO.File.Exists(outputInflow))
            {
                inFlowToolStripMenuItem.Enabled = true;
            }
            if (System.IO.File.Exists(outputHillflow))
            {
                hillFlowToolStripMenuItem.Enabled = true;
            }
            return true;
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveProjectAs SaveAsForm = new SaveProjectAs();
            SaveAsForm.Show();
        }

        private void CheckExistProject(string directory)
        {
            parameterToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            button2.Enabled = ProjectDirectory.Directory != "" ? true : false;
            saveProjectAsToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            saveToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            closeProjectToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            button1.Enabled = ProjectDirectory.Directory != "" ? true : false;
            button3.Enabled = ProjectDirectory.Directory != "" ? true : false;
            button4.Enabled = ProjectDirectory.Directory != "" ? true : false;
            wEHYToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            configurationOfRiverChannelRoutingSimulationToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            riverChannelRoutingSimulationToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            comprehensiveSimulationToolStripMenuItem.Enabled = ProjectDirectory.Directory != "" ? true : false;
            changeTreeView();
        }

        private void changeTreeView()
        {
            if (ProjectDirectory.Directory == "")
            {
                string path = RootDirectory.Directory + WEHY.Config.DirectoryConfig.Directory.ConfigFolder;
                ListDirectory(treeView2, path);
            }
            else
            {
                ListDirectory(treeView2, ProjectDirectory.Directory);
            }
        }

        private void ListDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }

        private void RunConfigForm()
        {
            try
            {
                EditConfig EditConfigForm = new EditConfig();
                EditConfigForm.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error : " + e);
            }
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectDirectory.Directory = "";
            MessageBox.Show("Project was Close !");
        }

        private void openRecentlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controllers.Common.RecentProjectCommon recentProject = new Controllers.Common.RecentProjectCommon();
            string path = recentProject.getRecentlyProjectPath();
            if (System.IO.File.Exists(path))
            {
                ProjectDirectory.Directory = System.IO.Path.GetDirectoryName(path);
                ProjectName.Name = System.IO.Path.GetFileName(path);
                MessageBox.Show("Open : " + ProjectDirectory.Directory);
            }
            else
            {
                MessageBox.Show("Recently Project is not Exist !");
            }
        }

        private void wEHYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckFile())
            {
                runController.RunWEHYSimulation();
                CheckExistOutputFile(OutputFolder);
            }
        }

        private void configurationOfRiverChannelRoutingSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckFile())
            {
                runController.RunConfigRiverChanel();
                CheckExistOutputFile(OutputFolder);
            }
        }

        private void riverChannelRoutingSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckFile())
            {
                runController.RunRiverChanelSimulation();
                CheckExistOutputFile(OutputFolder);
            }
        }

        private void comprehensiveSimulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckFile())
            {
                runController.RunAllProcess();
                CheckExistOutputFile(OutputFolder);
            }
        }

        private bool CheckFile()
        {
            if (!runController.CheckFile())
            {
                MessageBox.Show("Missing File : " + runController.GetMissingFile());
                return false;
            }
            return true;
        }
        /// <summary>
        /// Draw Hill Flow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hillFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckFile())
                {

                    Draw.HCHillFlow frmHillFlow = new Draw.HCHillFlow();
                    
                    frmHillFlow.Show();
                    frmHillFlow.OutputFile = OutputFolder;
                    frmHillFlow.BindRiverToCombobox();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Draw In Flow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckFile())
                {

                    Draw.HCRInflow frmRInFlow = new Draw.HCRInflow();
                    frmRInFlow.Show();
                    frmRInFlow.OutputFile = OutputFolder;
                    frmRInFlow.BindFlowToCombobox(0, new List<int>());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
        /// <summary>
        /// Draw Hydro Out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hydroOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckFile())
                {

                    Draw.HCHydroOut frmHydroOut = new Draw.HCHydroOut();

                    frmHydroOut.Show();
                    frmHydroOut.OutputFile = OutputFolder;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void geomorphologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preprocessing.Geomorphology frm = new Preprocessing.Geomorphology();
            frm.Show();
        }

        private void landUsecoverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void soilDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // treeView1.ExpandAll();
        }
    }
}
