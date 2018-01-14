using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Services;
using System.Collections.ObjectModel;
using PizzaWork.BusinessLayer.Models;
using System.Windows.Input;
using Pizzawork.Infrastructure;
using Pizzawork.Views.Order;

namespace Pizzawork.ViewModel.Order
{
    class OrderTabViewModel : BaseViewModel
    {
        private string _connectionName;
        private OrderService orderService;
        public int? SelectedOrderId { get; set; }

        private ObservableCollection<OrderViewModel> orders;

        public ObservableCollection<OrderViewModel> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }

        public OrderTabViewModel(string connectionName)
        {
            _connectionName = connectionName;
            orderService = new OrderService(connectionName);
            Orders = orderService.GetAll();
        }

        #region Commands
        private ICommand addCommand;
        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(Add));

        private void Add(object obj)
        {
            var dialogVM = new AddOrderDialogViewModel(_connectionName);
            var dialogWindow = new AddOrderDialog(dialogVM);
            dialogWindow.ShowDialog();
            if (dialogWindow.DialogResult == true)
            {
                try
                {
                    orderService.StartOrder(dialogVM.Order.ClientId, dialogVM.Order.PizzaId, dialogVM.Order);
                }
                catch (Exception e)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка заказа");
                }
                UpdateOrders();
            }
        }

        private ICommand stopCommand = null;

        //public ICommand StopCommand => stopCommand ?? (stopCommand = new RelayCommand(Stop, s=>SelectedOrderId!=null));
        public ICommand StopCommand => stopCommand ?? (stopCommand = new RelayCommand(Stop, s => {
            return SelectedOrderId != null && orderService.Get((int)SelectedOrderId).EndDateTime == null;
        }));


        private void Stop(object obj)
        {
            var dialogVM = new StopOrderDialogViewModel(_connectionName, SelectedOrderId);
            var dialogWnd = new StopOrderDialog(dialogVM);
            dialogWnd.ShowDialog();
            if (dialogWnd.DialogResult == true)
            {
                UpdateOrders();
            }
        }

        #endregion

        private void UpdateOrders()
        {
            orders.Clear();
            foreach (var order in orderService.GetAll())
            {
                orders.Add(order);
            }
        }

    }
}
