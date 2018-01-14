using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzawork.Infrastructure;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.BusinessLayer.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Pizzawork.ViewModel.Order
{
    public class StopOrderDialogViewModel
    {
        private string _connectionName;
        private int _orderId;
        public int? SelectedSpotId { get; set; }
        
        public ObservableCollection<SpotViewModel> Spots { get; set; }

        public StopOrderDialogViewModel(string connectionName, int? orderId)
        {
            if (orderId == null)
            {
                throw new ArgumentNullException("Id заказа");
            }
            _connectionName = connectionName;
            _orderId = (int)orderId;
            Spots = new SpotService(_connectionName).GetVacantSpots();
        }

        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok, p => SelectedSpotId != null));

        private void Ok(object parameter)
        {
            var orderService = new OrderService(_connectionName);
            try
            {
                orderService.StopOrder(_orderId, SelectedSpotId);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка завершения заказа");
            }
            if (parameter is Window dialogWindow)
            {
                dialogWindow.DialogResult = true;
                dialogWindow.Close();
            }
        }

    }
}
