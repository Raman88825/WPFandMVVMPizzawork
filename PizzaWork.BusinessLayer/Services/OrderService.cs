using PizzaWork.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PizzaWork.DataLayer.Repositories;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.DataLayer.Models;

namespace PizzaWork.BusinessLayer.Services
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(string name) : base(name){ }

        public void Create(OrderViewModel t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel Get(int id)
        {
            var mapper = AutoMapperConfigs.OrderToOrderVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return mapper.Map<Order, OrderViewModel>(database.Orders.Get(id));
            }

        }

        public ObservableCollection<OrderViewModel> GetAll()
        {
            var mapper = AutoMapperConfigs.OrderToOrderVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return new ObservableCollection<OrderViewModel>(mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(database.Orders.GetAll()));
            }
        }

        public void Update(OrderViewModel t)
        {
            throw new NotImplementedException();
        }

        public void StartOrder(int clientId, int pizzaId, OrderViewModel orderViewModel)
        {
            orderViewModel.StartDateTime = System.DateTime.Now;
            var mapper = AutoMapperConfigs.OrderVMToOrder.CreateMapper();
            var order = mapper.Map<Order>(orderViewModel);
            using (database = new EFUnitOfWork(connectionName))
            {
                var pizza = database.Pizzas.Get(pizzaId);
                pizza.SpotId = null;
                pizza.State = DataLayer.Enums.PizzaState.Ordered;
                var client = database.Clients.Get(clientId);
                if (client != null)
                {
                    client.Orders.Add(order);
                }
                database.Save();
            }
        }


        public void StopOrder(int orderId, int? endSpotId)
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                var order = database.Orders.Get(orderId);
                if (order.EndDateTime != null || order.EndSpotId != null)
                {
                    throw new InvalidOperationException("Заказ уже был завершен ранее");
                }
                order.EndSpotId = endSpotId;
                order.EndDateTime = System.DateTime.Now;
                order.Pizza.SpotId = endSpotId;
                database.Save();
            }
        }
    }
}
