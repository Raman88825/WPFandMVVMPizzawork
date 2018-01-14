using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.BusinessLayer.Interfaces;
using AutoMapper;
using PizzaWork.DataLayer.Models;
using PizzaWork.DataLayer.Repositories;
using PizzaWork.DataLayer.Enums;
using PizzaWork.BusinessLayer.Infrastructure;

namespace PizzaWork.BusinessLayer.Services
{
    public class PizzaService : BaseService, IPizzaService
    {
        public PizzaService(string name) : base(name){ }

        public void Create(PizzaViewModel pizzaViewModel)
        {
            pizzaViewModel.State = PizzaState.Ready;
            pizzaViewModel.AccessCode = new FourDigitCodeGenerator().Generate();
            var mapper = AutoMapperConfigs.PizzaVMToPizza.CreateMapper();
            var pizza = mapper.Map<Pizza>(pizzaViewModel);
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Pizzas.Create(pizza);
                database.Save();
            }
        }

        public void Delete(int pizzaId)
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Pizzas.Delete(pizzaId);
                database.Save();
            }
        }

        public PizzaViewModel Get(int pizzaId)
        {
            var mapper = AutoMapperConfigs.PizzaToPizzaVM.CreateMapper();
            return mapper.Map<PizzaViewModel>(database.Pizzas.Get(pizzaId));
        }

        public ObservableCollection<PizzaViewModel> GetActivePizzas()
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                var mapper = AutoMapperConfigs.PizzaToPizzaVM.CreateMapper();
                return mapper.Map<ObservableCollection<PizzaViewModel>>(database.Pizzas.Find(o => o.State != PizzaState.Deleted));
            }
        }

        public ObservableCollection<PizzaViewModel> GetAll()
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                var mapper = AutoMapperConfigs.PizzaToPizzaVM.CreateMapper();
                return mapper.Map<ObservableCollection<PizzaViewModel>>(database.Pizzas.GetAll());
            }
        }

        public void Update(PizzaViewModel pizzaVM)
        {
            var mapper = AutoMapperConfigs.PizzaVMToPizza.CreateMapper();
            var pizza = mapper.Map<Pizza>(pizzaVM);
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Pizzas.Update(pizza);
                database.Save();
            }
        }
    }
}
