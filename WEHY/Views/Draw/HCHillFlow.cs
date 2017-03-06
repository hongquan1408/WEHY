using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WEHY.Business;

namespace WEHY.Views.Draw
{
    public partial class HCHillFlow : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public int Count { get; set; }
        public HCHillFlow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bind data River
        /// </summary>
        public void BindRiverToCombobox()
        {
            LtsRiver = new List<Lookup> { new Lookup { ID = 0, Title = "Select River Flow" } };
            Lookup river;
            string fileName = @"" + OutputFile + "\\outputs\\HILLflow.csv";
            string line = string.Empty;
            try
            {
                using (var fs = System.IO.File.OpenRead(fileName))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        var values = line.Split(',');
                        Count++;
                        if (values[0].ToString() == "YEAR")
                        {
                            for (int i = 4; i < values.Count(); i++)
                            {
                                if (!string.IsNullOrEmpty(values[i]))
                                {
                                    river = new Lookup { ID = Convert.ToInt32(values[i]), Title = "River " + values[i].Trim() };
                                    LtsRiver.Add(river);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbbRiverFlow.DataSource = LtsRiver;
            cbbRiverFlow.DisplayMember = "Title";
            cbbRiverFlow.ValueMember = "ID";
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
            DataFlow data;
            int countData = 0;
            string line = string.Empty;
            try
            {
                using (var fs = System.IO.File.OpenRead(fileName))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        countData++;
                        line = reader.ReadLine();
                        if (countData > Count)
                        {
                            var values = line.Split(',');
                            if (!string.IsNullOrEmpty(values[0]) && Convert.ToInt32(values[0]) > 0)
                            {
                                data = new DataFlow();
                                data.Year = Convert.ToInt32(values[0]);
                                data.Month = Convert.ToInt32(values[1]);
                                data.Day = Convert.ToInt32(values[2]);
                                data.Hour = Convert.ToInt32(values[3]);
                                data.Value = Convert.ToDouble(values[3 + Flow]);
                                LtsDataFlow.Add(data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

            Lookup river = cbbRiverFlow.SelectedItem as Lookup;
            LtsDataFlow = GetDataFlowRiver(river.ID);
            if (LtsDataFlow.Count > 0)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"\bin\Debug", "");//
                var filePath = appPath + @"\Views\Html\HillFlow.html";
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        GenerateHtmlChart(w, appPath);
                    }
                }
                this.webBrowserchart.Url = new Uri(String.Format("file:///{0}/Views/Html/HillFlow.html", appPath));
                this.webBrowserchart.AutoSize = true;
            }
        }
        /// <summary>
        /// Generate Html chart
        /// </summary>
        /// <param name="w">StreamWriter</param>
        private void GenerateHtmlChart(StreamWriter w, string appPath)
        {
            w.WriteLine("<html><head>");
            w.WriteLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9;IE=10;IE=11;IE=EDGE\">");
            w.WriteLine("<title>Hill Flow Graph</title>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/jquery-1.11.2.min.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/highcharts.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/boost.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/exporting.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<style>");
            w.WriteLine("#container {height: 400px;min-width: 310px;max-width: 800px;margin: 0 auto;}");
            w.WriteLine("</style>");
            w.WriteLine("<script>");
            w.WriteLine("$(function () {");
            w.WriteLine("Highcharts.chart('container', {");
            w.WriteLine("chart: {");
            w.WriteLine("type: 'spline',");
            w.WriteLine("zoomType: 'x'");
            w.WriteLine("},");
            w.WriteLine("boost: {");
            w.WriteLine("useGPUTranslations: true");
            w.WriteLine("},");
            w.WriteLine("title: {");
            w.WriteLine("text: 'Hill Flow Graph'");
            w.WriteLine("},");
            w.WriteLine(" xAxis: {");
            w.WriteLine(" type: 'datetime',");
            w.WriteLine(" tickInterval: 7 * 24 * 3600 * 1000,");
            w.WriteLine("dateTimeLabelFormats: { ");
            w.WriteLine("month: '%e. %b',");
            w.WriteLine("year: '%b'");
            w.WriteLine("  },");
            w.WriteLine(" title: {");
            w.WriteLine("text: 'DateTime'");
            w.WriteLine("}");
            w.WriteLine("},");
            w.WriteLine("yAxis: {");
            w.WriteLine(" title: {");
            w.WriteLine("text: 'M2/s'");
            w.WriteLine("},");
            w.WriteLine("min: 0");
            w.WriteLine("},");
            w.WriteLine("tooltip: {");
            w.WriteLine("headerFormat: '<b>{series.name}</b><br>',");
            w.WriteLine("pointFormat: '{point.x:%Y-%b-%e}: {point.y:.6f} m'");
            w.WriteLine("},");
            w.WriteLine("plotOptions: {");
            w.WriteLine("spline: {");
            w.WriteLine("marker: {");
            w.WriteLine("enabled: true");
            w.WriteLine("}");
            w.WriteLine(" }");
            w.WriteLine(" },");
            w.WriteLine("series: [{");
            w.WriteLine("name: 'Hill Flow',");
            w.WriteLine("data: [");
            foreach (var item in LtsDataFlow)
            {
                w.WriteLine("[Date.UTC(" + item.Year + ", " + item.Month + ", " + item.Day + ", " + item.Hour + ", " + 0 + ", " + 0 + ", " + 0 + "), " + item.Value + "],");
            }
            w.WriteLine("]");
            w.WriteLine("}]");
            w.WriteLine("});");
            w.WriteLine("});");
            w.WriteLine("</script>");
            w.WriteLine("</head>");
            w.WriteLine("<body>");
            w.WriteLine("<div id=\"container\" style=\"min-width: 310px; height: 400px; margin: 0 auto\"></div>");
            w.WriteLine("</body>");
            w.WriteLine("</html>");
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
