using PizzaWork.DataLayer.EFContext;
using PizzaWork.DataLayer.Interfaces;
using PizzaWork.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.DataLayer.Repositories
{
    class OrdersRepository : BaseRepository<Order>, IRepository<Order>
    {
        public OrdersRepository(PizzaWorkContext context) : base(context)
        {
            table = context.Orders;
        }
    }
}
