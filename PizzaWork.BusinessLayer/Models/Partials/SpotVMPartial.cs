using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class SpotViewModel : ModelBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(Country):
                        errors = GetErrorsFromAnnotations(nameof(Country), Country);
                        break;
                    case nameof(Region):
                        errors = GetErrorsFromAnnotations(nameof(Region), Region);
                        break;
                    case nameof(District):
                        errors = GetErrorsFromAnnotations(nameof(District), District);
                        break;
                    case nameof(City):
                        errors = GetErrorsFromAnnotations(nameof(City), City);
                        break;
                    case nameof(Address):
                        errors = GetErrorsFromAnnotations(nameof(Address), Address);
                        break;
                    case nameof(Coordinates):
                        errors = GetErrorsFromAnnotations(nameof(Coordinates), Coordinates);
                        break;
                    case nameof(Capacity):
                        if (this.Capacity < this.Pizzas.Count)
                        {
                            AddError(nameof(Capacity), "Такое количество невозможно съесть");
                        }
                        errors = GetErrorsFromAnnotations(nameof(Capacity), Capacity);
                        break;
                }
                if (errors != null && errors.Length != 0)
                {
                    ClearErrors(columnName);
                    AddErrors(columnName, errors);
                    hasError = true;
                }
                if (!hasError) ClearErrors(columnName);
                return string.Empty;
            }
        }
        public string Error { get; }
    }
}
