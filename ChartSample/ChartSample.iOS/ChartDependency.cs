using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(ChartSample.iOS.ChartDependency))]

namespace ChartSample.iOS
{
    public class ChartDependency : ChartSample.IChartDependencyService
    {
        public async void SaveChart(string filename, Stream chart, Xamarin.Forms.Image image, Xamarin.Forms.Label alertText)
        {
            alertText.Text = "Exporting....";
            alertText.TextColor = Xamarin.Forms.Color.Red;
            await Task.Delay(2000);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filepath = Path.Combine(path, filename);
            FileStream outputFileStream = File.Open(filepath, FileMode.Create);
            MemoryStream fileStream = new MemoryStream();
            chart.CopyTo(fileStream);
            fileStream.Position = 0;
            fileStream.CopyTo(outputFileStream);
            outputFileStream.Close();
            await Task.Delay(2000);
            alertText.Text = "Export Location :" + filepath;
            alertText.TextColor = Xamarin.Forms.Color.Green;
            image.Source = filepath;
        }
    }
}