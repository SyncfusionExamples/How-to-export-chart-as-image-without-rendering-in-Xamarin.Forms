using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace ChartSample
{
    public interface IChartDependencyService
    {
        void SaveChart(string filename, Stream chart, Image image, Label label);
    }
}
