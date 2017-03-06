using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WEHY.Business;

namespace WEHY.Views.Draw
{
    public partial class RInflow : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public RInflow()
        {
            InitializeComponent();
            rbUpstream.Checked = false;
        }
        /// <summary>
        /// Bind data River
        /// </summary>
        private void BindFlowToCombobox(int sumFlow)
        {
            LtsRiver = new List<Lookup> { new Lookup { ID = 0, Title = "Select In Flow" } };
            Lookup river;

            for (int i = 1; i <= sumFlow; i++)
            {
                river = new Lookup { ID = i, Title = "In Flow " + i };
                LtsRiver.Add(river);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Event radio rbUbstream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbUpstream_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUpstream.Checked)
            {
                rbLateral.Checked = false;
                BindFlowToCombobox(11);
                cbbInflow.DataSource = LtsRiver;
                cbbInflow.DisplayMember = "Title";
                cbbInflow.ValueMember = "ID";
            }

        }
        /// <summary>
        /// Event radio rbLateral
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbLateral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLateral.Checked)
            {
                rbUpstream.Checked = false;
                BindFlowToCombobox(13);
                cbbInflow.DataSource = LtsRiver;
                cbbInflow.DisplayMember = "Title";
                cbbInflow.ValueMember = "ID";
            }

        }
        /// <summary>
        /// Get Data Flow River
        /// </summary>
        /// <param name="Flow"></param>
        /// <returns>List DataFow</returns>
        public List<DataFlow> GetDataInFlow(int Flow,int Type)
        {
            List<DataFlow> LtsDataFlow = new List<DataFlow>();
            string fileName = @"" + OutputFile + "\\outputs\\R_inflow.csv";
            DataTable dtData = new DataTable();
            try
            {
                var connString = string.Format(
                   @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""",
                   Path.GetDirectoryName(fileName)
               );
                using (var conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    var query = "SELECT * FROM [" + Path.GetFileName(fileName) + "]";
                    using (var adapter1 = new OleDbDataAdapter(query, conn))
                    {
                        var ds1 = new DataSet("CSV File");
                        adapter1.Fill(ds1);
                        dtData = ds1.Tables[0];
                    }
                }
                DataFlow data;
                string strDate;
                DateTime dtTime;
                int count = 0;
                foreach (DataRow item in dtData.Rows)
                {
                    count++;
                    if (count >= 5)
                    {
                        data = new DataFlow();
                        strDate = item[0].ToString();
                        if (!string.IsNullOrEmpty(strDate))
                        {
                            dtTime = DateTime.FromOADate(Convert.ToDouble(strDate));
                            data.Year = dtTime.Year;
                            data.Month = dtTime.Month;
                            data.Day = dtTime.Day;
                            data.Hour = dtTime.Hour;
                            data.Value = Convert.ToDouble(Type==1?item[Flow]:item[11+Flow]);
                            LtsDataFlow.Add(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\n\r Error: " + ex.Message + " !");
            }
            return LtsDataFlow;
        }
        /// <summary>
        /// Draw grap R In Flow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisulize_Click(object sender, EventArgs e)
        {
            var series = new Series("In Flow");
            List<DateTime> lstDate = new List<DateTime>();
            List<double> lstValue = new List<double>();
            Lookup river = cbbInflow.SelectedItem as Lookup;
            int Type = 0;
            Type = rbUpstream.Checked ? 1 : 2;
            LtsDataFlow = GetDataInFlow(river.ID, Type);
            if (LtsDataFlow.Count > 0)
            {
                foreach (var item in LtsDataFlow)
                {
                    var datetime = new DateTime(item.Year, item.Month, item.Day, 0, 0, 0);
                    lstDate.Add(datetime);
                    lstValue.Add(item.Value);
                }
                var minValue = lstValue.Min();
                var maxValue = lstValue.Max();
                series.Points.DataBindXY(lstDate.ToArray(), lstValue.ToArray());
                chartInFlow.ChartAreas[0].AxisY.ScaleView.Zoom(minValue, maxValue);
                chartInFlow.ChartAreas[0].CursorX.IsUserEnabled = true;
                chartInFlow.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chartInFlow.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chartInFlow.ChartAreas[0].AxisY.Title = "M2/s";
                chartInFlow.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Regular);
                series.ChartType = SeriesChartType.Line;
                chartInFlow.Series.Clear();
                chartInFlow.Series.Add(series);
            }
        }
    }
}
