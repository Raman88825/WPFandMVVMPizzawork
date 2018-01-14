using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PizzaWork.BusinessLayer.Interfaces
{
    public interface IBaseService<T>
    {
        ObservableCollection<T> GetAll();
        T Get(int id);
        void Create(T t);
        void Delete(int id);
        void Update(T t);
    }
}
