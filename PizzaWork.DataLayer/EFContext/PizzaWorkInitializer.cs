using PizzaWork.DataLayer.Models;
using System.Collections.Generic;
using System.Data.Entity;
using PizzaWork.DataLayer.Enums;

namespace PizzaWork.DataLayer.EFContext
{
    //internal class PizzaWorkInitializer : DropCreateDatabaseIfModelChanges<PizzaWorkContext>
    //internal class PizzaWorkInitializer : DropCreateDatabaseAlways<PizzaWorkContext>
    internal class PizzaWorkInitializer : CreateDatabaseIfNotExists<PizzaWorkContext>
    {
        protected override void Seed(PizzaWorkContext context)
        {
            context.Spots.Add(new Spot
            {
                Country = "Belarus",
                City = "Minsk",
                Address = "Маяковкого 11",
                Coordinates = System.Data.Entity.Spatial.DbGeography.FromText("POINT (27.568331 53.883146)"),
                Capacity = 30,
                State = SpotState.Active
            });
            context.Spots.Add(new Spot
            {
                Country = "Belarus",
                City = "Minsk",
                Address = "Октябрьская 50",
                Coordinates = System.Data.Entity.Spatial.DbGeography.FromText("POINT (27.576274 53.889550)"),
                Capacity = 30,
                State = SpotState.Active
            });

            context.SaveChanges();

            context.Clients.Add(new Client
            {
                LastName = "Петров",
                FirstName = "Александр",
                Patronymic = "Романович",
                PassportNumber = "MT9914789",
                RegistrationDate = new System.DateTime(2017, 05, 14),
                Email = "petroff99@gmail.com",
                Phone = "+3752911122233",
                State = ClientState.Active,
            });
            context.Clients.Add(new Client
            {
                LastName = "Васильев",
                FirstName = "Денис",
                Patronymic = "Евгеньевич",
                PassportNumber = "HB1584312",
                RegistrationDate = new System.DateTime(2017, 06, 21),
                Email = "vasilievdenis@gmail.com",
                Phone = "+375294447788",
                State = ClientState.Active,
            });
            context.Clients.Add(new Client
            {
                LastName = "Романов",
                FirstName = "Антон",
                Patronymic = "Эдуардович",
                PassportNumber = "MC4567891",
                RegistrationDate = new System.DateTime(2017, 06, 22),
                Email = "romanovanton@gmail.com",
                Phone = "+3752912345678",
                State = ClientState.Active,
            });

            context.PizzaTypes.AddRange(new PizzaType[]
                    { new PizzaType
                        {
                            Trademark = "Ramos Pizza",
                            Model = "КАРБОНАРА",
                            ImageLink = "Karbonara.png",
                            Description = "Бекон, Ветчина, Крем фреш, Лук, Сыр моцарелла, Шампиньоны",
                            Pizzas = new HashSet<Pizza>
                            { new Pizza { SerialNumber = "KA030", Size =30, AccessCode = 4084, State = PizzaState.Ready, PizzaTypeId = 1, SpotId = 1},
                            new Pizza {SerialNumber = "KA036", Size = 36, AccessCode = 8034, State = PizzaState.Ready, PizzaTypeId = 2, SpotId = 2}
                        }
                    },
                       new PizzaType
                           {
                            Trademark = "Ramos Pizza",
                            Model = "КАНТРИ",
                            ImageLink = "Kantri.png",
                            Description = "Бекон, Ветчина, Лук, Сыр моцарелла, Шампиньоны, Огурцы, Соус Чесночный",
                            Pizzas = new HashSet<Pizza>
                            { new Pizza { SerialNumber = "CA022", Size =22, AccessCode = 5517, State = PizzaState.Ordered, PizzaTypeId = 3, SpotId = null},
                            new Pizza {SerialNumber = "CA030", Size = 30, AccessCode = 1874, State = PizzaState.Ready, PizzaTypeId = 4, SpotId = 3}
                           }
                    }
                });
            context.SaveChanges();

            context.Orders.AddRange(new Order[]
            {
                new Order
                {
                    ClientId = 1,
                    PizzaId = 1,
                    StartSpotId = 1,
                    EndSpotId = 2,
                    StartDateTime = new System.DateTime(2017, 06, 15, 12, 0, 0),
                    EndDateTime = new System.DateTime(2017, 06, 15, 13, 30, 0)
                },
                new Order
                {
                    ClientId = 1,
                    PizzaId = 1,
                    StartSpotId = 2,
                    EndSpotId = 2,
                    StartDateTime = new System.DateTime(2017, 06, 16, 11, 0, 0),
                    EndDateTime = new System.DateTime(2017, 06, 16, 11, 30, 0)
                },
                new Order
                {
                    ClientId = 2,
                    PizzaId = 1,
                    StartSpotId = 2,
                    EndSpotId = 1,
                    StartDateTime = new System.DateTime(2017, 06, 21, 17, 0, 0),
                    EndDateTime = new System.DateTime(2017, 06, 21, 20, 30, 0)
                },
                new Order
                {
                    ClientId = 3,
                    PizzaId = 3,
                    StartSpotId = 1,
                    EndSpotId = null,
                    StartDateTime = new System.DateTime(2017, 06, 25, 18, 0, 0),
                    EndDateTime = null
                },
            });
            context.SaveChanges();
        }
    }
}
