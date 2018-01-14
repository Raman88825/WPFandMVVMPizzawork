using PizzaWork.BusinessLayer.Interfaces;
using PizzaWork.BusinessLayer.Models;
using PizzaWork.BusinessLayer.Services;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizzawork.Infrastructure;
using Pizzawork.Views.Spot;
using System.Data.Entity.Spatial;
using System.Windows.Input;
using System.Windows;

namespace Pizzawork.ViewModel
{
    public class SpotTabViewModel : BaseViewModel
    {
        #region fields
        private string _connectionName;
        private ISpotService spotService;
        private ObservableCollection<SpotViewModel> spots;
        public ObservableCollection<SpotViewModel> Spots
        {
            get => spots;
            private set
            {
                spots = value;
            }
        }

        private ObservableCollection<MapLocation> locations = new ObservableCollection<MapLocation>();

        public ObservableCollection<MapLocation> Locations
        {
            get { return locations; }
            private set { locations = value; }
        }

        private SpotViewModel selectedSpot;

        public SpotViewModel SelectedSpot
        {
            get { return selectedSpot; }
            set
            {
                if (selectedSpot != null)
                {
                    Locations.First(l => l.Id == selectedSpot.SpotId).IsActive = false;
                }
                selectedSpot = value;
                Locations.First(l => l.Id == selectedSpot.SpotId).IsActive = true;
                OnPropertyChanged();
            }
        }
        #endregion
        #region ctors
        public SpotTabViewModel(string connectionName)
        {
            _connectionName = connectionName;
            spotService = new SpotService(connectionName);
            Spots = spotService.GetActiveSpots();
            UpdateSpotsAndLocations();
        }
        #endregion
        #region methods


        private void UpdateSpotsAndLocations()
        {
            Spots.Clear();
            Locations.Clear();
            foreach (var spot in spotService.GetActiveSpots())
            {
                Spots.Add(spot);
                locations.Add(new MapLocation
                {
                    Location = new Location { Latitude = spot.Coordinates.Latitude ?? 0, Longitude = spot.Coordinates.Longitude ?? 0 },
                    IsActive = false,
                    Id = spot.SpotId,
                    ClickedCommand = PushPinClickedCommand,
                });
            }
        }
        #endregion
        #region Commands
        private ICommand addCommand = null;

        public ICommand AddCommand => addCommand ?? (addCommand = new RelayCommand(AddSpot));

        private void AddSpot(object obj)
        {
            var addDialogVM = new AddSpotDialogViewModel(_connectionName);
            var dialog = new AddSpotDialog(addDialogVM);
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                try
                {
                    spotService.Create(addDialogVM.Spot);
                }
                catch (Exception e)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка добавления точки проката");
                }
            }
            UpdateSpotsAndLocations();
        }

        private ICommand deleteCommand = null;

        public ICommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(DeleteSpot, s => SelectedSpot != null));

        private void DeleteSpot(object obj)
        {
            var res = MessageBox.Show("Вы уверены?", "Удаление точки", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.Cancel) return;
            try
            {
                spotService.Delete(SelectedSpot.SpotId);
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(e, "Ошибка удаления точки");
            }
            UpdateSpotsAndLocations();
        }

        private ICommand refreshCommand = null;
        public ICommand RefreshCommand => refreshCommand ?? (refreshCommand = new RelayCommand(c => UpdateSpotsAndLocations()));

        private ICommand pushPinClickedCommand = null;

        public ICommand PushPinClickedCommand => pushPinClickedCommand ?? (pushPinClickedCommand = new RelayCommand(OnPushpinClicked));

        private void OnPushpinClicked(object obj)
        {
            if (obj is CommandablePushpin pushpin)
            {
                SelectedSpot = Spots.First(i => i.SpotId == pushpin.Id);
            }
        }

        #endregion

    }
}