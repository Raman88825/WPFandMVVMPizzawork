using Pizzawork.ViewModel.Client;
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

namespace Pizzawork.Views.Client
{
    /// <summary>
    /// Interaction logic for AddClientDialog.xaml
    /// </summary>
    public partial class AddClientDialog : Window
    {
        private AddClientDialogViewModel _vm;

        public AddClientDialog()
        {
            InitializeComponent();
        }

        public AddClientDialog(AddClientDialogViewModel vm) : this()
        {
            _vm = vm;
            DataContext = _vm;
        }
    }
}
