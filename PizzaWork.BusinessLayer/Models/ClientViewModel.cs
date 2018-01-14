using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PizzaWork.DataLayer.Enums;
using System.ComponentModel.DataAnnotations;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class ClientViewModel
    {
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
        [EnumDataType(typeof(PizzaWork.DataLayer.Enums.ClientState))]
        public ClientState State { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required, Phone()]
        public string Phone { get; set; }
        [Range(0, 5)]
        public double Rating { get; set; }

        public ObservableCollection<OrderViewModel> Orders { get; set; }
    }
}
