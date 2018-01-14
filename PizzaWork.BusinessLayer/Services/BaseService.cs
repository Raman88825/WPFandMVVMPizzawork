using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.DataLayer.Interfaces;
using PizzaWork.DataLayer.Repositories;

namespace PizzaWork.BusinessLayer.Services
{
    public abstract class BaseService
    {
        protected IUnitOfWork database;
        protected string connectionName;
        public BaseService(string name)
        {
            connectionName = name;
        }
    }
}
