using PizzaWork.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaWork.BusinessLayer.Models;
using System.Collections.ObjectModel;
using AutoMapper;
using PizzaWork.DataLayer.Models;
using PizzaWork.DataLayer.Repositories;
using PizzaWork.DataLayer.Enums;

namespace PizzaWork.BusinessLayer.Services
{
    public class SpotService : BaseService, ISpotService
    {
        private string _connectionName;
        public SpotService(string connectionName) : base(connectionName)
        {
            _connectionName = connectionName;
        }

        public void Create(SpotViewModel spotViewModel)
        {
            spotViewModel.State = SpotState.Active;
            Mapper.Initialize(cfg => cfg.CreateMap<SpotViewModel, Spot>());
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Spots.Create(Mapper.Map<Spot>(spotViewModel));
                database.Save();
            }
        }

        public void Delete(int spotId)
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                database.Spots.Delete(spotId);
                database.Save();
            }
        }

        public SpotViewModel Get(int spotId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Spot, SpotViewModel>());
            using (database = new EFUnitOfWork(connectionName))
            {
                return Mapper.Map<SpotViewModel>(database.Spots.Get(spotId));
            }
        }

        public ObservableCollection<SpotViewModel> GetAll()
        {
            var mapper = AutoMapperConfigs.SpotToSpotVM.CreateMapper();
            using (database = new EFUnitOfWork(_connectionName))
            {
                return mapper.Map<ObservableCollection<SpotViewModel>>(database.Spots.GetAll());
            }
        }

        public void Update(SpotViewModel spotViewModel)
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                var mapper = AutoMapperConfigs.SpotVMToSpot.CreateMapper();
                var spot = mapper.Map<Spot>(spotViewModel);
                using (database = new EFUnitOfWork(connectionName))
                {
                    database.Spots.Update(spot);
                    database.Save();
                }
            }
        }

        public ObservableCollection<SpotViewModel> GetVacantSpots()
        {
            var mapper = AutoMapperConfigs.SpotToSpotVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {

                //return mapper.Map<ObservableCollection<SpotViewModel>>(database
                //        .Spots.GetAll().Where(s => (s.Capacity - s.Pizzas.Count) > 0));
                //Если делать по нормальному, то:
                //InvalidOperationException: Существует назначенный этой команде Command открытый DataReader,
                //который требуется предварительно закрыть
                return mapper.Map<ObservableCollection<SpotViewModel>>(database
                    .Spots
                    .Find(s => ((s.Capacity - s.Pizzas.Count) > 0)));
            }
        }

        public ObservableCollection<SpotViewModel> GetActiveSpots()
        {
            var mapper = AutoMapperConfigs.SpotToSpotVM.CreateMapper();
            using (database = new EFUnitOfWork(_connectionName))
            {
                return mapper.Map<ObservableCollection<SpotViewModel>>(database.Spots.Find(s => s.State != SpotState.Deleted));
            }
        }
    }
}
