using Pizzawork.ViewModel;
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

namespace Pizzawork.Views.Pizza
{
    /// <summary>
    /// Interaction logic for AddEditPizzaDialog.xaml
    /// </summary>
    public partial class AddEditPizzaDialog : Window
    {
        public AddEditPizzaDialog()
        {
            InitializeComponent();
        }

        public AddEditPizzaDialog(AddEditPizzaDialogViewModel dialogVM) : this()
        {
            DataContext = dialogVM;
        }
    }
}
