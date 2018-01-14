using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using PizzaWork.DataLayer.Enums;
using System.Xml.Serialization;

namespace PizzaWork.BusinessLayer.Models
{
    [Serializable]
    public partial class PizzaViewModel
    {
        public int PizzaId { get; set; }
        [Required(ErrorMessage = "Обязательное поле"), StringLength(50, ErrorMessage = "Длина не должна превышать 50 символов")]
        public string SerialNumber { get; set; }
        [Range(20, 36, ErrorMessage = "Размер должен быть числом от 20 до 36")]
        public int? Size { get; set; }
        public int? AccessCode { get; set; }
        [Required, EnumDataType(typeof(PizzaState), ErrorMessage = "Недопустимое значение состояния")]
        public PizzaState State { get; set; }
        public int PizzaTypeId { get; set; }
        public int? SpotId { get; set; }

        [XmlIgnore]
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        [XmlIgnore]
        public virtual PizzaTypeViewModel PizzaType { get; set; }
        [XmlIgnore]
        public virtual SpotViewModel Spot { get; set; }

    }
}