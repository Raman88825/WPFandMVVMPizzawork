using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.DataLayer.Models
{
    public partial class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int PizzaId { get; set; }
        public int StartSpotId { get; set; }
        public int? EndSpotId { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public virtual Pizza Pizza { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(StartSpotId))]
        public virtual Spot StartSpot { get; set; }
        [ForeignKey(nameof(EndSpotId))]
        public virtual Spot EndSpot { get; set; }
    }
}
