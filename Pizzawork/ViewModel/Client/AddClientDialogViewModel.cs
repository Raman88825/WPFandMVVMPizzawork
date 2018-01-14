using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using System.Windows.Input;
using Pizzawork.Infrastructure;
using System.Windows;

namespace Pizzawork.ViewModel.Client
{
    public class AddClientDialogViewModel : BaseViewModel
    {
        private string _connectioName;

        private ClientViewModel client = new ClientViewModel();

        public ClientViewModel Client
        {
            get { return client; }
            set { client = value; }
        }

        public AddClientDialogViewModel(string connectionName)
        {
            _connectioName = connectionName;
        }

        private ICommand okCommand = null;

        public ICommand OkCommand => okCommand ?? (okCommand = new RelayCommand(Ok, u=>!Client.HasErrors));

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
