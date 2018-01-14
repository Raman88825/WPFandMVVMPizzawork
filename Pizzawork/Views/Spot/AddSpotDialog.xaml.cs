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
using Pizzawork.ViewModel;
using Microsoft.Maps.MapControl.WPF;

namespace Pizzawork.Views.Spot
{
    /// <summary>
    /// Interaction logic for AddSpotDialog.xaml
    /// </summary>
    public partial class AddSpotDialog : Window
    {
        private AddSpotDialogViewModel _addDialogVM;

        public AddSpotDialog()
        {
            InitializeComponent();
        }

        public AddSpotDialog(AddSpotDialogViewModel vm) : this()
        {
            _addDialogVM = vm;
            DataContext = vm;
            this.Map.MouseDoubleClick += OnMap_MouseDoubleClick;
        }

        private void OnMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var location = new Location();
            Map.TryViewportPointToLocation(e.GetPosition(this.Map), out location);
            var pushpin = new Pushpin();
            pushpin.SetValue(MapLayer.PositionProperty, location);
            this.Map.Children.Clear();
            this.Map.Children.Add(pushpin);
            _addDialogVM.SelectedLocation = location;

        }
    }
}
