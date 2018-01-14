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
    class clientsRepository : BaseRepository<Client>, IRepository<Client>
    {
        public clientsRepository(PizzaWorkContext context) : base(context)
        {
            table = context.Clients;
        }

        public override void Delete(int id)
        {
            var client = context.Clients.Find(id);
            if (client != null)
            {
                client.State = Enums.ClientState.Deleted;
            }
        }
    }
}
