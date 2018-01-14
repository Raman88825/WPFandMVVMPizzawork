using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.DataLayer.Enums;

namespace PizzaWork.DataLayer.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int PizzaId { get; set; }
        [Required, StringLength(50), Index("Idx_Number", IsUnique = true)]
        public string SerialNumber { get; set; }
        [Range(12, 24)]
        public int? Size { get; set; }
        public int? AccessCode { get; set; }
        [Required, EnumDataType(typeof(PizzaState))]
        public PizzaState State { get; set; }
        public int PizzaTypeId { get; set; }
        public int? SpotId { get; set; }

        public virtual PizzaType PizzaType { get; set; }
        public virtual Spot Spot { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
