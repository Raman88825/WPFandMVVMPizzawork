using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using PizzaWork.DataLayer.Enums;

namespace PizzaWork.BusinessLayer.Models
{
    public partial class SpotViewModel : ModelBase
    {
        public int SpotId { get; set; }
        private string country;

        [Required, StringLength(255)]
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }

        private string region;

        [StringLength(255)]
        public string Region
        {
            get { return region; }
            set
            {
                region = value;
                OnPropertyChanged();
            }
        }

        private string district;
        [StringLength(255)]
        public string District
        {
            get { return district; }
            set
            {
                district = value;
                OnPropertyChanged();
            }
        }

        private string city;
        [Required, StringLength(255)]
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        //Change to Address
        private string address;
        [Required, StringLength(255)]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        [Required]
        public DbGeography Coordinates { get; set; }

        [Required, Range(1, 100)]
        public int? Capacity { get; set; }
        [EnumDataType(typeof(PizzaWork.DataLayer.Enums.SpotState))]
        public SpotState State { get; set; }

        public ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        public ObservableCollection<OrderViewModel> OrdersStart { get; set; }
        public ObservableCollection<OrderViewModel> OrderEnd { get; set; }
    }
}
