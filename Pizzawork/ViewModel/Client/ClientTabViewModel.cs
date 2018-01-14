using PizzaWork.BusinessLayer.Interfaces;
using PizzaWork.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PizzaWork.BusinessLayer.Models;
using System.Windows.Input;
using Pizzawork.Infrastructure;
using Pizzawork.Views.Client;

namespace Pizzawork.ViewModel.Client
{
    public class ClientTabViewModel : BaseViewModel
    {
        #region fields
        private string _connectionName;

        private IClientService clientService;

        private ObservableCollection<ClientViewModel> clients;

        public ObservableCollection<ClientViewModel> Clients
        {
            get { return clients; }
            private set
            {
                clients = value;
                OnPropertyChanged();
            }
        }

        private ClientViewModel selectedClient = null;

        public ClientViewModel SelectedClient
        {
            get { return selectedClient; }
            set { selectedClient = value; }
        }
        #endregion
        #region ctors
        public ClientTabViewModel(string connectionName)
        {
            _connectionName = connectionName;
            clientService = new ClientService(connectionName);
            Clients = clientService.GetActiveClients();
        }
        #endregion
        #region Commands
        private ICommand addCommand = null;

        public ICommand AddCommand => addCommand ?? (new RelayCommand(Add));

        private void Add(object obj)
        {
            var dialogVM = new AddClientDialogViewModel(_connectionName);
            var dialogWindow = new AddClientDialog(dialogVM);
            dialogWindow.ShowDialog();
            if (dialogWindow.DialogResult == true)
            {
                try
                {
                    clientService.Create(dialogVM.Client);
                }
                catch (Exception e)
                {

                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка добавления клиента");

                }
            }
            UpdateClients();
        }

        public ICommand deleteCommand = null;
        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(Delete, s => SelectedClient != null));

        private void Delete(object parameter)
        {
            try
            {
                clientService.Delete(SelectedClient.ClientId);
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка удаления клиента");
            }
            UpdateClients();
        }
        #endregion
        #region methods
        private void UpdateClients()
        {
            Clients.Clear();
            foreach (var client in clientService.GetActiveClients())
            {
                Clients.Add(client);
            }
        }
        #endregion
    }
}
