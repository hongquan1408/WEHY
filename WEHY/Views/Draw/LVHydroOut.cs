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
using WEHY.Business;

namespace WEHY.Views.Draw
{
    public partial class LVHydroOut : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<Lookup> LtsType { get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        public LVHydroOut()
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
        public ChartValues<DateTimePoint> GetDataInFlow(int Flow, int Type)
        {
            int count = 0;
            var valuesChart = new ChartValues<DateTimePoint>();
            int Year;
            int Month;
            int Day;
            int Hour;
            double value;
            DateTime dtTime;
            string fileName = @"" + OutputFile + "\\outputs\\R_hydro_out.csv";

            using (var fs = System.IO.File.OpenRead(fileName))
            using (var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {

                    count++;
                    var line = reader.ReadLine();
                    if (count >= 6)
                    {
                            var values = line.Split(',');
                            dtTime = DateTime.FromOADate(Convert.ToDouble(values[0].ToString()));
                            Year = dtTime.Year;
                            Month = dtTime.Month;
                            Day = dtTime.Day;
                            Hour = dtTime.Hour;
                            value = Convert.ToDouble(Type == 1 ? values[Flow] : values[11 + Flow]);
                            valuesChart.Add(new DateTimePoint(new DateTime(Year, Month, Day, Hour, 0, 0), value));
                    }
                }
            }

            return valuesChart;
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
        /// <summary>
        /// Draw graph
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisulize_Click(object sender, EventArgs e)
        {
           
            Lookup river = cbbRiverFlow.SelectedItem as Lookup;
            Lookup type = cbbType.SelectedItem as Lookup;

            cartesianChart1.Series = new SeriesCollection{
            new LineSeries
            {
                Values = GetDataInFlow(river.ID, type.ID),
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
        /// <summary>
        /// Close Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
