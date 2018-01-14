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
    class SpotsRepository : BaseRepository<Spot>, IRepository<Spot>
    {
        public SpotsRepository(PizzaWorkContext context) : base(context)
        {
            table = context.Spots;
        }

        public override void Delete(int id)
        {
            var spot = context.Spots.Find(id);
            if (spot != null)
            {
                spot.State = Enums.SpotState.Deleted;
            }
        }
    }
}
