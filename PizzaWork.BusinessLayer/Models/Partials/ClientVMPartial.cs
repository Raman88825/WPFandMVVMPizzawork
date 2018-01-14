using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class ClientViewModel : ModelBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(LastName):
                        errors = GetErrorsFromAnnotations(nameof(LastName), LastName);
                        break;
                    case nameof(FirstName):
                        errors = GetErrorsFromAnnotations(nameof(FirstName), FirstName);
                        break;
                    case nameof(Patronymic):
                        errors = GetErrorsFromAnnotations(nameof(Patronymic), Patronymic);
                        break;
                    case nameof(PassportNumber):
                        errors = GetErrorsFromAnnotations(nameof(PassportNumber), PassportNumber);
                        break;
                    case nameof(RegistrationDate):
                        errors = GetErrorsFromAnnotations(nameof(RegistrationDate), RegistrationDate);
                        break;
                    case nameof(State):
                        errors = GetErrorsFromAnnotations(nameof(State), State);
                        break;
                    case nameof(Email):
                        errors = GetErrorsFromAnnotations(nameof(Email), Email);
                        break;
                    case nameof(Phone):
                        errors = GetErrorsFromAnnotations(nameof(Phone), Phone);
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
