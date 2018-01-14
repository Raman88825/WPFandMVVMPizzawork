using PizzaWork.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzawork.ViewModel.PizzaType
{
    public class ChartVM : BaseViewModel
    {
        public ObservableCollection<PizzaTypeViewModel> Types;

        public ChartVM(IEnumerable<PizzaTypeViewModel> types)
        {
            Types = new ObservableCollection<PizzaTypeViewModel>(types);
        }
    }
}
