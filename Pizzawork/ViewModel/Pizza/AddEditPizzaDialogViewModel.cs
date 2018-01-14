using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.BusinessLayer.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pizzawork.Infrastructure;
using System.Windows;
using System.Data.Entity.Validation;

namespace Pizzawork.ViewModel
{
    public class AddEditPizzaDialogViewModel : BaseViewModel
    {
        private string _connectionName;
        private string pizzaTypeText;

        public string PizzaTypeText

        {
            get { return pizzaTypeText; }
            set
            {
                pizzaTypeText = value;
                OnPropertyChanged();
            }
        }

        private string spotText;

        public string SpotText
        {
            get { return spotText; }
            set
            {
                spotText = value;
                OnPropertyChanged();
            }
        }


        private PizzaTypeViewModel selectedPizzaType;

        public PizzaTypeViewModel SelectedPizzaType
        {
            get { return selectedPizzaType; }
            set
            {
                selectedPizzaType = value;
                OnPropertyChanged();
            }
        }
        private SpotViewModel selectedSpot;

        public SpotViewModel SelectedSpot
        {
            get { return selectedSpot; }
            set
            {
                selectedSpot = value;
                OnPropertyChanged();
            }
        }

        private PizzaViewModel _pizza = null;
        public PizzaViewModel Pizza
        {
            get => _pizza ?? (_pizza = new PizzaViewModel());
            set => _pizza = value;
        }


        public ObservableCollection<SpotViewModel> Spots { get; set; }

        public ObservableCollection<PizzaTypeViewModel> Models { get; set; }


        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok, o => !Pizza.HasErrors && SelectedSpot != null && SelectedPizzaType != null));

        private void Ok(object parameter)
        {
            Pizza.SpotId = this.SelectedSpot.SpotId;
            if (parameter is Window dialogWindow)
            {
                dialogWindow.DialogResult = true;
                dialogWindow.Close();
            }
        }

        public AddEditPizzaDialogViewModel(PizzaViewModel pizza, string connectionName)
        {
            _pizza = pizza;
            _connectionName = connectionName;
            Spots = new SpotService(connectionName).GetActiveSpots();
            Models = new PizzaTypeService(connectionName).GetActivePizzaTypes();
            SelectedPizzaType = pizza?.PizzaType;
            SelectedSpot = pizza?.Spot;
            PizzaTypeText = pizza?.PizzaType.FullModelName;
            SpotText = pizza?.Spot?.Address;
        }
    }
}
