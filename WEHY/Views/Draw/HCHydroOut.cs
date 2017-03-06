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
using WEHY.Business;

namespace WEHY.Views.Draw
{
    public partial class HCHydroOut : Form
    {
        public List<Lookup> LtsRiver { get; set; }
        public List<Lookup> LtsType { get; set; }
        
        public List<DataFlow> LtsDataFlow { get; set; }
        public string OutputFile { get; set; }
        public List<int> LtsStartIndexGroup { get; set; }
        public int Count { get; set; }
        public int CountRiver { get; set; }
        public HCHydroOut()
        {

            InitializeComponent();
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
                DataFlow data;
                string strDate;
                DateTime dtTime;
                string line = string.Empty;
                int countData = 0;
                double value = 0;
                using (var fs = System.IO.File.OpenRead(fileName))
                using (var reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        countData++;

                        line = reader.ReadLine();
                        var values = line.Split(',');
                        if (countData > Count && double.TryParse(values[0], out value))
                        {
                            if (value > 0)
                            {
                                data = new DataFlow();
                                strDate = values[0].ToString();
                                if (!string.IsNullOrEmpty(strDate))
                                {
                                    dtTime = DateTime.FromOADate(Convert.ToDouble(strDate));
                                    data.Year = dtTime.Year;
                                    data.Month = dtTime.Month;
                                    data.Day = dtTime.Day;
                                    data.Hour = dtTime.Hour;
                                    data.Value = Convert.ToDouble(values[(Type - 1) * CountRiver + Flow]);
                                    LtsDataFlow.Add(data);
                                }
                            }
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
        /// Bind data to combobox
        /// </summary>
        private void BindRiverToCombobox(int Type, List<int> LtsData)
        {
            LtsStartIndexGroup = new List<int>();
            string fileName = @"" + OutputFile + "\\outputs\\R_inflow.csv";
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

                        int CountValue = values.Count();
                        if (values[0].ToString().Contains("L="))
                        {

                            for (int i = 1; i < CountValue; i++)
                            {
                                if (values[i] == "1")
                                {
                                    LtsStartIndexGroup.Add(i);
                                }
                            }

                            LtsData.Add(Convert.ToInt32(values[LtsStartIndexGroup[Type]]));
                            for (int j = LtsStartIndexGroup[Type] + 1; j < CountValue; j++)
                            {
                                if (values[j] == values[LtsStartIndexGroup[Type]])
                                    break;
                                else
                                {
                                    LtsData.Add(Convert.ToInt32(values[j]));
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

            LtsDataFlow = GetDataInFlow(river.ID, type.ID);
            if (LtsDataFlow.Count > 0)
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"\bin\Debug", "");//
                var filePath = appPath + @"\Views\Html\HydroOut.html";
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        GenerateHtmlChart(w, appPath);
                    }
                }
                this.webBrowserChart.Url = new Uri(String.Format("file:///{0}/Views/Html/HydroOut.html", appPath));
                this.webBrowserChart.AutoSize = true;
            }
        }
        /// <summary>
        /// Generate Html chart
        /// </summary>
        /// <param name="w">StreamWriter</param>
        private void GenerateHtmlChart(StreamWriter w, string appPath)
        {
            var imageLoading = "<div style='text-align:center'><img src=\"file:///" + appPath + "/Views/Html/loading.gif\" alt='Đang tải dữ liệu'/></div>";
            w.WriteLine("<html><head>");
            w.WriteLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=9;IE=10;IE=11;IE=EDGE\">");
            w.WriteLine("<title>Hydro Out Graph</title>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/jquery-1.11.2.min.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/highcharts.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/boost.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<script src=\"file:///" + appPath + "/Views/Html/exporting.js\" type=\"text/javascript\"></script>");
            w.WriteLine("<style>");
            w.WriteLine("#container {height: 400px;min-width: 310px;max-width: 800px;margin: 0 auto;}");
            w.WriteLine("</style>");
            w.WriteLine("<script>");
            w.WriteLine("$(function () {");
            //w.WriteLine("$('#container').html('<div style='text-align:center'><img src=\"file:///" + appPath + "/Views/Html/loading.gif\" alt='Đang tải dữ liệu'/></div>');");

            w.WriteLine("Highcharts.chart('container', {");
            w.WriteLine("chart: {");
            w.WriteLine("type: 'spline',");
            w.WriteLine("zoomType: 'x'");
            w.WriteLine("},");
            w.WriteLine("boost: {");
            w.WriteLine("useGPUTranslations: true");
            w.WriteLine("},");
            w.WriteLine("title: {");
            w.WriteLine("text: 'Graph Hydro Out'");
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
            w.WriteLine("name: 'Hydro Out',");
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
        /// Close Chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
