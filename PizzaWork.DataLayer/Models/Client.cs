using PizzaWork.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.DataLayer.Models
{
    public partial class Client
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int ClientId { get; set; }
        [Required, StringLength(12)]
        public string PassportNumber { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string Patronymic { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required, EnumDataType(typeof(ClientState))]
        public ClientState State { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required, Phone()]
        public string Phone { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
