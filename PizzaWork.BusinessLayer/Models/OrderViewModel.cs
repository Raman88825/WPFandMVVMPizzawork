using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.BusinessLayer.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public int PizzaId { get; set; }
        public int StartSpotId { get; set; }
        public int? EndSpotId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public TimeSpan? Duration
        {
            get
            {
                if (EndDateTime != null)
                    return EndDateTime - StartDateTime;
                return null;
            }
        }

        public virtual PizzaViewModel Pizza { get; set; }
        public virtual ClientViewModel Client { get; set; }
        public virtual SpotViewModel StartSpot { get; set; }
        public virtual SpotViewModel EndSpot { get; set; }
    }
}
