using Pizzawork.ViewModel.Client;
using Pizzawork.Views.Pizza;
using Pizzawork.Views.PizzaType;
using Pizzawork.Views.Spot;
using Pizzawork.Views.Client;
using Pizzawork.Views.Order;
using Pizzawork.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using NLog;

namespace Pizzawork.ViewModel
{
    class MainViewModel
    {
        private readonly string _connectionName = "MSSQL_PizzaWorks";
        private PizzaTabViewModel pizzaTabVM;

        public PizzaTabViewModel PizzasVM => pizzaTabVM;

        private PizzaTypeTabViewModel pizzaTypeTabVM;

        public PizzaTypeTabViewModel PizzaTypeVM => pizzaTypeTabVM;

        private SpotTabViewModel spotTabViewModel;
        public SpotTabViewModel SpotVM => spotTabViewModel;

        private ClientTabViewModel clientTabViewModel;
        public ClientTabViewModel ClientVM => clientTabViewModel;

        private OrderTabViewModel orderTabViewModel;
        public OrderTabViewModel OrderVM => orderTabViewModel;
        
        public UserControl SpotUC { get; set; }
        public UserControl PizzaUC { get; set; }
        public UserControl PizzaTypeUC { get; set; }
        public UserControl ClientUC { get; set; }
        public UserControl OrderUC { get; set; }
        
        public MainViewModel()
        {
            pizzaTabVM = new PizzaTabViewModel(_connectionName);
            pizzaTypeTabVM = new PizzaTypeTabViewModel(_connectionName);
            spotTabViewModel = new SpotTabViewModel(_connectionName);
            clientTabViewModel = new ClientTabViewModel(_connectionName);
            orderTabViewModel = new OrderTabViewModel(_connectionName);
            SpotUC = new SpotTabUC();
            PizzaUC = new PizzaTabUC();
            PizzaTypeUC = new PizzaTypeUC();
            ClientUC = new ClientTabUC();
            OrderUC = new OrderTabUC();
        }
    }
}
