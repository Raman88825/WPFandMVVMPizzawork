using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.DataLayer.Models
{
    public partial class PizzaType
    {
        public PizzaType()
        {
            this.Pizzas = new HashSet<Pizza>();
        }
        [Key, Required]
        public int PizzaTypeId { get; set; }
        [StringLength(255)]
        public string Trademark { get; set; }
        [Required, StringLength(255)]
        public string Model { get; set; }
        [StringLength(255)]
        public string ImageLink { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public bool isDeleted { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
