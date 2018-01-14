using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.DataLayer.Models;

namespace PizzaWork.DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PizzaType> PizzaTypes { get; }
        IRepository<Pizza> Pizzas { get; }
        IRepository<Client> Clients { get; }
        IRepository<Spot> Spots { get; }
        IRepository<Order> Orders { get; }

        void Save();
    }
}
