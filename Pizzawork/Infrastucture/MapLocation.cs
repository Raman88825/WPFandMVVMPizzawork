using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pizzawork.Infrastructure
{
    public class MapLocation : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ClickedCommand { get; set; }

        public MapLocation() { }

        public MapLocation(double latitude, double longitude)
        {
            Location = new Location(latitude, longitude);
        }
    }
}

