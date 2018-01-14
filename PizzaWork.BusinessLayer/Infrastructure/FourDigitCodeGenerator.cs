using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Interfaces;

namespace PizzaWork.BusinessLayer.Infrastructure
{
    class FourDigitCodeGenerator : IAccessCodeGenerator
    {
        public int Generate()
        {
            var rnd = new Random();
            return rnd.Next(1000, 9999);
        }
    }
}
