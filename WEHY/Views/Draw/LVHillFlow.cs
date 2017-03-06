using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using WEHY.Business;

namespace WEHY.Views.Draw
{
    public partial class LVHillFlow : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public LVHillFlow()
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
        private ChartValues<DateTimePoint> GetDataFlowRiver(int Flow)
        {
            string fileName = @"" + OutputFile + "\\outputs\\HILLflow.csv";
            int count = 0;
            var valuesChart = new ChartValues<DateTimePoint>();
            int Year;
            int Month;
            int Day;
            int Hour;
            double value;
            using (var fs = System.IO.File.OpenRead(fileName))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    count++;
                    var line = reader.ReadLine();
                    if (count >= 89)
                    {
                        var values = line.Split(',');
                        Year = Convert.ToInt32(values[0].Trim());
                        Month = Convert.ToInt32(values[1].Trim());
                        Day = Convert.ToInt32(values[2].Trim());
                        Hour = Convert.ToInt32(values[3].Trim());
                        value = Convert.ToDouble(values[3 + Flow].Trim());
                        valuesChart.Add(new DateTimePoint(new DateTime(Year, Month, Day, Hour, 0, 0), value));
                    }
                   // if (count > 9000) break;
                }
            }
            return valuesChart;
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
        /// <summary>
        /// Render graph Hill Flow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisulize_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series = new SeriesCollection{
            new LineSeries
            {
                Values = GetDataFlowRiver(1),
            }
        };
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Zoom = ZoomingOptions.X;
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "DateTime",
                LabelFormatter = val => new DateTime((long)val).ToString("dd MMMM")
            });
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "M2/s",
                LabelFormatter = val => val.ToString("N")
            });
            cartesianChart1.DataClick += CartesianChart1OnDataClick;
        }
        /// <summary>
        /// Click point
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="chartPoint"></param>
        private void CartesianChart1OnDataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }
    }
}
