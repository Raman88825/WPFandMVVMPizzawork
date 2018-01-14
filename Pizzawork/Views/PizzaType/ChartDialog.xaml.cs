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
using System.Windows.Shapes;
using Pizzawork.ViewModel.PizzaType;
using Pizzawork.Views.Charts;

namespace Pizzawork.Views.PizzaType
{
    /// <summary>
    /// Interaction logic for ChartDialog.xaml
    /// </summary>
    public partial class ChartDialog : Window
    {
        public PizzaTypeChart ChartUC { get; set; }

        public ChartDialog()
        {
            InitializeComponent();
        }

        public ChartDialog(ChartVM chartVM) : this()
        {
            DataContext = this;
            ChartUC = new PizzaTypeChart(chartVM.Types);
        }
    }
}
