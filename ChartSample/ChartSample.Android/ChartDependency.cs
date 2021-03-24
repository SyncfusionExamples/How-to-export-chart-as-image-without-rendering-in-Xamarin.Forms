using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(ChartSample.Droid.ChartDependency))]

namespace ChartSample.Droid
{
   public class ChartDependency : ChartSample.IChartDependencyService
    {
        public async void SaveChart(string filename, Stream chart, Xamarin.Forms.Image image, Xamarin.Forms.Label alertText)
        {
            string root = null;
            alertText.Text = "Exporting....";
            alertText.TextColor = Xamarin.Forms.Color.Red;
            await Task.Delay(2000);
          
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();
            Java.IO.File file = new Java.IO.File(myDir, filename);
            if (file.Exists()) file.Delete();
            Java.IO.FileOutputStream fileOutputStream = new Java.IO.FileOutputStream(file);
            MemoryStream fileStream = (MemoryStream)chart;
            fileOutputStream.Write(fileStream.ToArray());
            var resultPath = file.Path;
            fileOutputStream.Flush();
            fileOutputStream.Close();
            await Task.Delay(2000);
            alertText.Text = "Export Location :"+resultPath;
            alertText.TextColor = Xamarin.Forms.Color.Green;
            image.Source = resultPath;
        }
    }
}