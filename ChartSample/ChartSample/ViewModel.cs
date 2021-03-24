using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ChartSample
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
     
        public ViewModel()
        {
            Data = new ObservableCollection<Model>();
            Data.Add(new Model() { Category = "USA", Value = 20 });
            Data.Add(new Model() { Category = "Germany", Value = 45 });
            Data.Add(new Model() { Category = "Spain", Value = 25 });
            Data.Add(new Model() { Category = "UK", Value = 36 });
            Data.Add(new Model() { Category = "Japan", Value = 57 });
        }
    }

    public class Model
    {
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
