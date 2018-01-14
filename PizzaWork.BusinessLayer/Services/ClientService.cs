using PizzaWork.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using System.Collections.ObjectModel;
using AutoMapper;
using PizzaWork.DataLayer.Models;
using PizzaWork.DataLayer.Repositories;

namespace PizzaWork.BusinessLayer.Services
{
    public class ClientService : BaseService, IClientService
    {
        private string _connectionName;
        public ClientService(string connectionName) : base(connectionName)
        {
            _connectionName = connectionName;
        }


        public void Create(ClientViewModel clientVM)
        {
            clientVM.RegistrationDate = DateTime.Now;
            var mapper = AutoMapperConfigs.ClientVMToClient.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Clients.Create(mapper.Map<Client>(clientVM));
                database.Save();
            }
        }

        public void Delete(int ClientId)
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Clients.Delete(ClientId);
                database.Save();
            }
        }


        public ClientViewModel Get(int id)
        {
            var mapper = AutoMapperConfigs.ClientToClientVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return mapper.Map<ClientViewModel>(database.Clients.Get(id));
            }
        }

        public ObservableCollection<ClientViewModel> GetActiveClients()
        {
            var mapper = AutoMapperConfigs.ClientToClientVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return mapper.Map<ObservableCollection<ClientViewModel>>(database.
                    Clients.
                    Find(u => u.State != DataLayer.Enums.ClientState.Deleted));
            }
        }

        public ObservableCollection<ClientViewModel> GetAll()
        {
            var mapper = AutoMapperConfigs.ClientToClientVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return mapper.Map<ObservableCollection<ClientViewModel>>(database.Clients.GetAll());
            }
        }

        public void Update(ClientViewModel clientVM)
        {
            var mapper = AutoMapperConfigs.ClientVMToClient.CreateMapper();
            var client = mapper.Map<Client>(clientVM);
            using (database)
            {
                database.Clients.Update(client);
                database.Save();
            }
        }
    }
}
