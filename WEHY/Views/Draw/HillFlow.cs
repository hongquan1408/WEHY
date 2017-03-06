using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WEHY.Business;

namespace WEHY.Views.Draw
{
    using System.IO;

    public partial class HillFlow : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public HillFlow()
        {
            InitializeComponent();
            BindRiverToCombobox();
            cbbRiverFlow.DataSource = LtsRiver;
            cbbRiverFlow.DisplayMember = "Title";
            cbbRiverFlow.ValueMember = "ID";

        }
        /// <summary>
        /// Bind data River
        /// </summary>
        private void BindRiverToCombobox()
        {
            LtsRiver = new List<Lookup> { new Lookup { ID = 0, Title = "Select River Flow" } };
            Lookup river;

            for (int i = 1; i <= 54; i++)
            {
                river = new Lookup { ID = i, Title = "River " + i };
                LtsRiver.Add(river);
            }
        }

        /// <summary>
        /// Get Data Flow River
        /// </summary>
        /// <param name="Flow"></param>
        /// <returns>List DataFow</returns>
        public List<DataFlow> GetDataFlowRiver(int Flow)
        {
            List<DataFlow> LtsDataFlow = new List<DataFlow>();
            string fileName = @"" + OutputFile + "\\outputs\\HILLflow.csv";
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
                int count = 0;
                foreach (DataRow item in dtData.Rows)
                {
                    count++;
                    if (count >= 88)
                    {
                        data = new DataFlow();
                        data.Year = Convert.ToInt32(item[0]);
                        data.Month = Convert.ToInt32(item[1]);
                        data.Day = Convert.ToInt32(item[2]);
                        data.Hour = Convert.ToInt32(item[3]);
                        data.Value = Convert.ToDouble(item[3 + Flow]);
                        LtsDataFlow.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\n\r Error: " + ex.Message+" !");
            }
            return LtsDataFlow;
        }
        /// <summary>
        /// Get data old
        /// </summary>
        /// <param name="Flow"></param>
        /// <returns></returns>
        public List<DataFlow> GetDataFlowRiverOld(int Flow)
        {
            List<DataFlow> LtsDataFlow = new List<DataFlow>();
            try
            {

                DataTable dtData = new DataTable();
                var filename = @"E:\HILLflow.csv";
                var connString = string.Format(
                    @"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=YES;FMT=Delimited""",
                    Path.GetDirectoryName(filename)
                );
                using (var conn = new OleDbConnection(connString))
                {
                    conn.Open();
                    var query = "SELECT * FROM [" + Path.GetFileName(filename) + "]";
                    using (var adapter1 = new OleDbDataAdapter(query, conn))
                    {
                        var ds1 = new DataSet("CSV File");
                        adapter1.Fill(ds1);
                        dtData = ds1.Tables[0];
                    }
                }

                DataFlow data;
                int count = 0;
                foreach (DataRow item in dtData.Rows)
                {
                    count++;
                    if (count >= 88)
                    {
                        data = new DataFlow();
                        data.Year = Convert.ToInt32(item[0]);
                        data.Month = Convert.ToInt32(item[1]);
                        data.Day = Convert.ToInt32(item[2]);
                        data.Hour = Convert.ToInt32(item[3]);
                        data.Value = Convert.ToDouble(item[3 + Flow]);
                        LtsDataFlow.Add(data);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("\n\r Có lỗi trong việc Import \r\n Có thể bạn nhập sai tên sheet trong excel: " + ex.Message);
            }
            return LtsDataFlow;
        }
        /// <summary>
        /// Draw graph line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisulize_Click(object sender, EventArgs e)
        {
            var series = new Series("River Flow");
            List<DateTime> lstDate = new List<DateTime>();
            List<double> lstValue = new List<double>();
            Lookup river = cbbRiverFlow.SelectedItem as Lookup;
            LtsDataFlow = GetDataFlowRiver(river.ID);
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
                chartRiverFlow.ChartAreas[0].AxisY.ScaleView.Zoom(minValue, maxValue);
                chartRiverFlow.ChartAreas[0].CursorX.IsUserEnabled = true;
                chartRiverFlow.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chartRiverFlow.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chartRiverFlow.ChartAreas[0].AxisY.Title = "M2/s";
                chartRiverFlow.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Regular);
                series.ChartType = SeriesChartType.Line;
                chartRiverFlow.Series.Clear();
                chartRiverFlow.Series.Add(series);
            }
        }
        /// <summary>
        /// Close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
