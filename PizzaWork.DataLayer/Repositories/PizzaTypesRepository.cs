using PizzaWork.DataLayer.Models;
using PizzaWork.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.DataLayer.EFContext;

namespace PizzaWork.DataLayer.Repositories
{
    class PizzaTypesRepository : BaseRepository<PizzaType>, IRepository<PizzaType>
    {
        public PizzaTypesRepository(PizzaWorkContext context) : base(context)
        {
            table = context.PizzaTypes;
        }

        public override void Delete(int id)
        {
            var pizzaType = context.PizzaTypes.Find(id);
            if (pizzaType != null)
            {
                pizzaType.isDeleted = true;
            }
        }
    }
}
