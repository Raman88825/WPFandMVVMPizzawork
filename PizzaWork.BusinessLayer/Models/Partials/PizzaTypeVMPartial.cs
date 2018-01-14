using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class PizzaTypeViewModel : ModelBase, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string[] errors = null;
                bool hasError = false;
                switch (columnName)
                {
                    case nameof(Trademark):
                        errors = GetErrorsFromAnnotations(nameof(Trademark), Trademark);
                        break;
                    case nameof(Model):
                        errors = GetErrorsFromAnnotations(nameof(Model), Model);
                        break;
                    case nameof(Description):
                        errors = GetErrorsFromAnnotations(nameof(Description), Description);
                        break;
                    case nameof(ImageLink):
                        errors = GetErrorsFromAnnotations(nameof(ImageLink), ImageLink);
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
