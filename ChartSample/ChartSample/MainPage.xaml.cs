using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChartSample
{
   
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       
        private void Button_Clicked(object sender, EventArgs e)
        {
           
            DependencyService.Get<IChartDependencyService>().SaveChart("SavedImage.jpg", GetChart().GetStream(), image, exportLabel);
        }

        private SfChart GetChart()
        {
            return new SfChart()
            {
                PrimaryAxis = new CategoryAxis(),
                SecondaryAxis = new NumericalAxis(),
                Series=
                {
                    new ColumnSeries()
                    {
                        ItemsSource = new ViewModel().Data,
                        XBindingPath = "Category",
                        YBindingPath = "Value"
                    }
                }
            };
          
        }

    }
}
