using Pizzawork.Infrastructure;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pizzawork.ViewModel.Order
{
    public class AddOrderDialogViewModel
    {
        private string _connectionName;
        private OrderViewModel order = new OrderViewModel();
        public OrderViewModel Order
        {
            get { return order; }
            set { order = value; }
        }

        public ObservableCollection<ClientViewModel> Clients { get; set; }
        public ObservableCollection<SpotViewModel> Spots { get; set; }



        public AddOrderDialogViewModel(string connectionName)
        {
            _connectionName = connectionName;
            Clients = new ClientService(connectionName).GetActiveClients();
            Spots = new SpotService(connectionName).GetActiveSpots();
        }

        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok));

        private void Ok(object parameter)
        {
            if (parameter is Window dialogWindow)
            {
                dialogWindow.DialogResult = true;
                dialogWindow.Close();
            }
        }
    }
}
