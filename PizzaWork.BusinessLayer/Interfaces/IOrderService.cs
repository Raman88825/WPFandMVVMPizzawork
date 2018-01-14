using PizzaWork.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Interfaces
{
    interface IOrderService : IBaseService<OrderViewModel>
    {
        void StartOrder(int clientId, int pizzaId, OrderViewModel orderViewModel);
        void StopOrder(int orderId, int? endSpotId);
    }
}
