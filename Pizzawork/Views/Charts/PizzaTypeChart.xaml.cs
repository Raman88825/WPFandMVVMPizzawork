using PizzaWork.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Pizzawork.Views.Charts
{
    /// <summary>
    /// Interaction logic for PizzaTypeChart.xaml
    /// </summary>
    public partial class PizzaTypeChart : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }

        public PizzaTypeChart()
        {
            InitializeComponent();
        }
        public PizzaTypeChart(ObservableCollection<PizzaTypeViewModel> types) : this()
        {
            DataContext = this;
            SeriesCollection = new SeriesCollection();

            foreach (var type in types)
            {
                var p = new PieSeries
                {
                    Title = type.Model,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(type.Pizzas.Count) },
                    DataLabels = true
                };
                SeriesCollection.Add(p);
            }
        }
    }
}
