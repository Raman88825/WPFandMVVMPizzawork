using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using PizzaWork.DataLayer.Enums;

namespace PizzaWork.DataLayer.Models
{
    public partial class Spot
    {
        public Spot()
        {
            this.Pizzas = new HashSet<Pizza>();
            this.OrdersStart = new HashSet<Order>();
            this.OrdersEnd = new HashSet<Order>();
        }
        [Key]
        public int SpotId { get; set; }
        [Required, StringLength(255)]
        public string Country { get; set; }
        [StringLength(255)]
        public string Region { get; set; }
        [StringLength(255)]
        public string District { get; set; }
        [Required, StringLength(255)]
        public string City { get; set; }
        [Required, StringLength(255)]
        public string Address { get; set; }
        [Required]
        public DbGeography Coordinates { get; set; }
        [Required]
        public int? Capacity { get; set; }
        [Required, EnumDataType(typeof(SpotState))]
        public SpotState State { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
        public virtual ICollection<Order> OrdersStart { get; set; }
        public virtual ICollection<Order> OrdersEnd { get; set; }
    }
}
