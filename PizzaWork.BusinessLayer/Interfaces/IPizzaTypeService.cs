using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PizzaWork.BusinessLayer.Models;

namespace PizzaWork.BusinessLayer.Interfaces
{
    public interface IPizzaTypeService : IBaseService<PizzaTypeViewModel>
    {
        ObservableCollection<PizzaTypeViewModel> GetActivePizzaTypes();
    }
}
