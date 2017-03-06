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
    public partial class LVRInFlow : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public LVRInFlow()
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
            string fileName = @"" + OutputFile + "\\outputs\\R_inflow.csv";

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
                            value = Convert.ToDouble(values[(Type - 1) * 13 + Flow]);
                            valuesChart.Add(new DateTimePoint(new DateTime(Year, Month, Day, Hour, 0, 0), value));
                    }
                }
            }

            return valuesChart;
        }
        /// <summary>
        /// Draw grap R In Flow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVisulize_Click(object sender, EventArgs e)
        {
            Lookup river = cbbInflow.SelectedItem as Lookup;
            int Type = 0;
            Type = rbUpstream.Checked ? 1 : 2;
            cartesianChart1.Series = new SeriesCollection{
            new LineSeries
            {
                Values = GetDataInFlow(river.ID, Type),
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
        /// Close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
