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
using Pizzawork.ViewModel.Order;

namespace Pizzawork.Views.Order
{
    /// <summary>
    /// Interaction logic for StopOrderDialog.xaml
    /// </summary>
    public partial class StopOrderDialog : Window
    {
        public StopOrderDialog()
        {
            InitializeComponent();
        }

        public StopOrderDialog(StopOrderDialogViewModel vm) : this()
        {
            DataContext = vm;
        }
    }
}
