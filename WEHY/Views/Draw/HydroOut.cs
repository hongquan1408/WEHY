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
    public partial class HydroOut : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<Lookup> LtsType{ get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public HydroOut()
        {
            InitializeComponent();
            BindRiverToCombobox();
            BindTypeToCombobox();
            cbbRiverFlow.DataSource = LtsRiver;
            cbbRiverFlow.DisplayMember = "Title";
            cbbRiverFlow.ValueMember = "ID";
            cbbType.DataSource = LtsType;
            cbbType.DisplayMember = "Title";
            cbbType.ValueMember = "ID";
        }
        /// <summary>
        /// Bind data River
        /// </summary>
        private void BindTypeToCombobox()
        {
            LtsType = new List<Lookup> { new Lookup { ID = 0, Title = "Select Type" } };

            LtsType.Add(new Lookup { ID = 1, Title = "Down" });
            LtsType.Add(new Lookup { ID = 2, Title = "Mid" });
            LtsType.Add(new Lookup { ID = 3, Title = "Up" });
          
        }
        /// <summary>
        /// Get Data Flow River
        /// </summary>
        /// <param name="Flow"></param>
        /// <returns>List DataFow</returns>
        public List<DataFlow> GetDataInFlow(int Flow, int Type)
        {
            List<DataFlow> LtsDataFlow = new List<DataFlow>();
            string fileName = @"" + OutputFile + "\\outputs\\R_hydro_out.csv";
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
                            data.Value =Convert.ToDouble(item[(Type-1)*13+Flow]);
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
        /// Bind data River
        /// </summary>
        private void BindRiverToCombobox()
        {
            LtsRiver = new List<Lookup> { new Lookup { ID = 0, Title = "Select River Flow" } };
            Lookup river;

            for (int i = 1; i <= 13; i++)
            {
                river = new Lookup { ID = i, Title = "River " + i };
                LtsRiver.Add(river);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Draw graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisulize_Click(object sender, EventArgs e)
        {
            var series = new Series("Hydro Out");
            List<DateTime> lstDate = new List<DateTime>();
            List<double> lstValue = new List<double>();
            Lookup river = cbbRiverFlow.SelectedItem as Lookup;
            Lookup type = cbbType.SelectedItem as Lookup;
           
            LtsDataFlow = GetDataInFlow(river.ID, type.ID);
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
                chartHydroOut.ChartAreas[0].AxisY.ScaleView.Zoom(minValue, maxValue);
                chartHydroOut.ChartAreas[0].CursorX.IsUserEnabled = true;
                chartHydroOut.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
                chartHydroOut.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                chartHydroOut.ChartAreas[0].AxisY.Title = "M2/s";
                chartHydroOut.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 11, System.Drawing.FontStyle.Regular);
                series.ChartType = SeriesChartType.Line;
                chartHydroOut.Series.Clear();
                chartHydroOut.Series.Add(series);
            }
        }
    }
}
