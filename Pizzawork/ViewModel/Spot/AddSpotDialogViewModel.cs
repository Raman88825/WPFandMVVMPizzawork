using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using Microsoft.Maps.MapControl.WPF;
using Geocoding;
using Geocoding.Microsoft;
using System.Windows;
using System.Collections.ObjectModel;
using Pizzawork.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Input;
using System.Globalization;

namespace Pizzawork.ViewModel
{
    public class AddSpotDialogViewModel : BaseViewModel
    {
        #region fields
        private string _connectionName;

        public string SearchRequest { get; set; }

        private SpotViewModel spot = new SpotViewModel();

        public SpotViewModel Spot
        {
            get { return spot; }
            set { spot = value; }
        }

        private Microsoft.Maps.MapControl.WPF.Location selectedLocation;
        public Microsoft.Maps.MapControl.WPF.Location SelectedLocation
        {
            get { return selectedLocation; }
            internal set
            {
                selectedLocation = value;
                GetAddressses(selectedLocation);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MapLocation> findedLocations = new ObservableCollection<MapLocation>();

        public ObservableCollection<MapLocation> FindedLocations
        {
            get { return findedLocations; }
            set { findedLocations = value; }
        }


        private ObservableCollection<Geocoding.Address> findedAddresses = new ObservableCollection<Address>();

        public ObservableCollection<Geocoding.Address> FindedAddresses
        {
            get => findedAddresses;
            set => findedAddresses = value;
        }
        #endregion
        #region ctors
        public AddSpotDialogViewModel(string connectionName)
        {
            _connectionName = connectionName;
        }
        #endregion
        #region methods
        private int selectedAddressIndex;

        public int SelectedAddressIndex
        {
            get { return selectedAddressIndex; }
            set
            {
                selectedAddressIndex = value;
                SetAddress(FindedAddresses[value]);
                OnPropertyChanged();
            }
        }

        private void SetAddress(Address value)
        {
            try
            {
                var json = JObject.Parse(value.ToJSON().ToString());
                Spot.Country = (string)json["CountryRegion"];
                Spot.City = (string)json["Locality"];
                Spot.Address = (string)json["AddressLine"];
            }
            catch (JsonReaderException e)
            {
                MessageBox.Show(e.Message);
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка чтения адреса");
            }
        }

        private void GetAddressses(Microsoft.Maps.MapControl.WPF.Location location)
        {
            FindedAddresses.Clear();
            string key = ((ApplicationIdCredentialsProvider)Application.Current.TryFindResource("BingMapKey")).ApplicationId;
            if (key == null) return;
            BingMapsGeocoder geocoder = new BingMapsGeocoder(key)
            {
                Culture = "Ru-ru"
            };
            var requestResult = geocoder.ReverseGeocode(new Geocoding.Location(location.Latitude, location.Longitude));
            //DistinctBy 
            var distinctResult = requestResult.GroupBy(a => a.FormattedAddress).Select(a => a.First());
            foreach (var address in distinctResult)
            {
                FindedAddresses.Add(address);
            }
            SelectedAddressIndex = 0;
            OnPropertyChanged(nameof(FindedAddresses));
        }
        #endregion.
        #region commands

        private ICommand okCommand = null;

        public ICommand OKCommand => okCommand ?? (okCommand = new RelayCommand(Ok, o => !Spot.HasErrors));

        private void Ok(object parameter)
        {
            if (parameter is Window dialogWindow)
            {
                Spot.Coordinates = System.Data.Entity.Spatial.DbGeography.
                    FromText(String.Format(
                        new NumberFormatInfo { NumberDecimalSeparator = "." }, "POINT ({0} {1})",
                        SelectedLocation.Longitude, SelectedLocation.Latitude));
                dialogWindow.DialogResult = true;
                dialogWindow.Close();
            }
        }

        private ICommand searchCommand = null;

        public ICommand SearchCommand => searchCommand ?? (searchCommand = new RelayCommand(Search, o => !string.IsNullOrEmpty(SearchRequest)));

        private void Search(object obj)
        {
            FindedLocations.Clear();
            string key = ((ApplicationIdCredentialsProvider)Application.Current.TryFindResource("BingMapKey")).ApplicationId;
            if (key == null) return;
            BingMapsGeocoder geocoder = new BingMapsGeocoder(key)
            {
                Culture = "By-ru"
            };

            try
            {
                var requestResult = geocoder.Geocode(SearchRequest);
                foreach (var location in requestResult)
                {
                    FindedLocations.Add(new MapLocation(location.Coordinates.Latitude, location.Coordinates.Longitude));
                    OnPropertyChanged(nameof(FindedLocations));
                }

            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка поиска");
            }
        }
        #endregion
    }
}