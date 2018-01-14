using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.DataLayer.Interfaces;
using PizzaWork.DataLayer.EFContext;
using PizzaWork.DataLayer.Models;

namespace PizzaWork.DataLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PizzaWorkContext context;
        private PizzaTypesRepository pizzaModelRepository;
        private PizzasRepository pizzasRepository;
        private clientsRepository clientsRepository;
        private OrdersRepository ordersRepository;
        private SpotsRepository spotRepository;

        public EFUnitOfWork(string name)
        {
            context = new PizzaWorkContext(name);
        }

        public IRepository<PizzaType> PizzaTypes
        {
            get
            {
                if (pizzaModelRepository == null)
                {
                    pizzaModelRepository = new PizzaTypesRepository(context);
                }
                return pizzaModelRepository;
            }
        }

        public IRepository<Pizza> Pizzas
        {
            get
            {
                if (pizzasRepository == null)
                {
                    pizzasRepository = new PizzasRepository(context);
                }
                return pizzasRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientsRepository == null)
                {
                    clientsRepository = new clientsRepository(context);
                }
                return clientsRepository;
            }
        }

        public IRepository<Spot> Spots
        {
            get
            {
                if (spotRepository == null)
                {
                    spotRepository = new SpotsRepository(context);
                }
                return spotRepository;
            }
        }


        public IRepository<Order> Orders
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new OrdersRepository(context);
                }
                return ordersRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
