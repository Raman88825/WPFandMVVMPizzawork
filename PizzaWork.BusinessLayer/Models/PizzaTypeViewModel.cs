using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class PizzaTypeViewModel
    {
        public int PizzaTypeId { get; set; }
        [StringLength(255)]
        public string Trademark { get; set; }
        [Required(ErrorMessage = "Обязательное поле"), StringLength(255)]
        public string Model { get; set; }
        private string imageLink;
        [StringLength(255)]
        public string ImageLink
        {
            get { return imageLink; }
            set
            {
                imageLink = value;
                OnPropertyChanged();
            }
        }
        [StringLength(1000)]
        public string Description { get; set; }

        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }

        public string FullModelName
        {
            get
            {
                return Trademark + " " + Model;
            }
        }
    }
}
