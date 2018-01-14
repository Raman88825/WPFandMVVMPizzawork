using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PizzaWork.DataLayer.Models;
using PizzaWork.BusinessLayer.Models;

namespace PizzaWork.BusinessLayer
{
    public static class AutoMapperConfigs
    {
        private static MapperConfiguration VMtoEntity
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PizzaViewModel, Pizza>();
                    cfg.CreateMap<PizzaTypeViewModel, PizzaType>();
                    cfg.CreateMap<OrderViewModel, Order>().PreserveReferences();
                    cfg.CreateMap<SpotViewModel, Spot>().PreserveReferences();
                    cfg.CreateMap<ClientViewModel, Client>();
                });
            }
        }

        private static MapperConfiguration EntityToVM
        {
            get
            {
                return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Pizza, PizzaViewModel>();
                    cfg.CreateMap<PizzaType, PizzaTypeViewModel>();
                    cfg.CreateMap<Spot, SpotViewModel>().PreserveReferences();
                    cfg.CreateMap<Order, OrderViewModel>().PreserveReferences();
                    cfg.CreateMap<Client, ClientViewModel>();
                });
            }
        }

        public static MapperConfiguration PizzaVMToPizza
        {
            get => VMtoEntity;
        }

        public static MapperConfiguration PizzaToPizzaVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration PizzaTypeVMToPizzaType
        {
            get => VMtoEntity;
        }

        public static MapperConfiguration PizzaTypeToPizzaTypeVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration SpotToSpotVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration SpotVMToSpot
        {
            get => VMtoEntity;
        }

        public static MapperConfiguration ClientToClientVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration ClientVMToClient
        {
            get => VMtoEntity;
        }

        public static MapperConfiguration OrderToOrderVM
        {
            get => EntityToVM;
        }

        public static MapperConfiguration OrderVMToOrder
        {
            get => VMtoEntity;
        }
    }
}
