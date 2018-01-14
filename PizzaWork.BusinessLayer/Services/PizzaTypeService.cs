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
    public class PizzaTypeService : BaseService, IPizzaTypeService
    {
        public PizzaTypeService(string name) : base(name){ }

        public void Create(PizzaTypeViewModel pizzaTypeVM)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PizzaTypeViewModel, PizzaType>();
                cfg.CreateMap<SpotViewModel, Spot>().PreserveReferences(); //.PreserveReferences for avoid circuit references => stackoverflowException
                cfg.CreateMap<PizzaViewModel, Pizza>();
            });
            using (database = new EFUnitOfWork(connectionName))
            {
                database.PizzaTypes.Create(Mapper.Map<PizzaType>(pizzaTypeVM));
                database.Save();
            }
        }

        public void Delete(int id)
        {
            using (database = new EFUnitOfWork(connectionName))
            {
                database.PizzaTypes.Delete(id);
                database.Save();
            }
        }

        public PizzaTypeViewModel Get(int id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<PizzaType, PizzaTypeViewModel>();
                cfg.CreateMap<Spot, SpotViewModel>().PreserveReferences(); //.PreserveReferences for avoid circuit references => stackoverflowException
                cfg.CreateMap<Pizza, PizzaViewModel>();
            });
            using (database = new EFUnitOfWork(connectionName))
            {
                return Mapper.Map<PizzaTypeViewModel>(database.PizzaTypes.Get(id));
            }
        }

        public ObservableCollection<PizzaTypeViewModel> GetActivePizzaTypes()
        {
            var mapper = AutoMapperConfigs.PizzaTypeToPizzaTypeVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return new ObservableCollection<PizzaTypeViewModel>(mapper.Map<IEnumerable<PizzaType>, IEnumerable<PizzaTypeViewModel>>(database.PizzaTypes.Find(b => b.isDeleted != true)));
            }
        }

        public ObservableCollection<PizzaTypeViewModel> GetAll()
        {
            var mapper = AutoMapperConfigs.PizzaTypeToPizzaTypeVM.CreateMapper();
            using (database = new EFUnitOfWork(connectionName))
            {
                return new ObservableCollection<PizzaTypeViewModel>(mapper.Map<IEnumerable<PizzaType>, IEnumerable<PizzaTypeViewModel>>(database.PizzaTypes.GetAll()));
            }
        }

        public void Update(PizzaTypeViewModel pizzaTypeVM)
        {
            var mapper = AutoMapperConfigs.PizzaTypeVMToPizzaType.CreateMapper();
            var pizzaType = mapper.Map<PizzaType>(pizzaTypeVM);
            using (database = new EFUnitOfWork(connectionName))
            {
                database.PizzaTypes.Update(pizzaType);
                database.Save();
            }
        }
    }
}
