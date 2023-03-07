using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.Http;
using System.IO;

namespace progaexam
{
    class Ploting
    {
        private Chart chart;
        private Func<double, double> f;
        private HttpClient client;
        public Ploting(Chart chart, Func<double,double> func)
        {
            this.chart = chart;
            this.f = func;
            client = new HttpClient();
        }
        public void ShowPlot(double a, double b, double ep)
        {
            for (double i = a; i <=b; i+=ep)
            {
                this.chart.Series[0].Points.AddXY(i, f(i));
            }
        }
        public void SavePlot()
        {
            this.chart.SaveImage("plot.jpeg", ChartImageFormat.Jpeg);
        }
        public void Post()
        {
            var formContent = new MultipartFormDataContent();
            //var vals = new Dictionary<string, string>
            //{
            //    {"filename", "graph.jpeg" }
            //};
            //var tcontent = new FormUrlEncodedContent(vals);
            var file = File.ReadAllBytes("plot.jpeg");
            var fcontent = new ByteArrayContent(file, 0, file.Length);
            formContent.Add(fcontent, "image", "plot.jpeg");
            //formContent.Add(tcontent, "image");
            client.PostAsync("http://exam/loadImage.php", formContent);
        }
        public void Get()
        {
            StringBuilder req = new StringBuilder("http://exam/show_data.php?data=");
            req.Append("1+3+7");
            client.GetAsync(req.ToString());
        }
        public string Debug()
        {
            var formContent = new MultipartFormDataContent();
            var file = File.ReadAllBytes("plot.jpeg");
            var fcontent = new ByteArrayContent(file, 0, file.Length);
            formContent.Add(fcontent, "image", "plot.jpeg");
            return file.ToString();
        }
    }
}
