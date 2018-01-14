using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class PizzaViewModel : ModelBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(SerialNumber):
                        errors = GetErrorsFromAnnotations(nameof(SerialNumber), SerialNumber);
                        break;
                    case nameof(Size):
                        errors = GetErrorsFromAnnotations(nameof(Size), Size);
                        break;
                    case nameof(State):
                        errors = GetErrorsFromAnnotations(nameof(State), State);
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
