using PizzaWork.DataLayer.Interfaces;
using PizzaWork.DataLayer.EFContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.DataLayer.Models;
using PizzaWork.DataLayer.Enums;

namespace PizzaWork.DataLayer.Repositories
{
    class PizzasRepository : BaseRepository<Pizza>, IRepository<Pizza>
    {
        public PizzasRepository(PizzaWorkContext context) : base(context)
        {
            table = context.Pizzas;
        }

        public override void Delete(int id)
        {
            var pizza = context.Pizzas.Find(id);
            if (pizza != null)
            {
                pizza.State = PizzaState.Deleted;
            }
        }
    }
}
