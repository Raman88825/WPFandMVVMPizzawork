using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace PizzaWork.BusinessLayer.Interfaces
{
    public interface ISpotService : IBaseService<SpotViewModel>
    {
        ObservableCollection<SpotViewModel> GetVacantSpots();
        ObservableCollection<SpotViewModel> GetActiveSpots();
    }
}
