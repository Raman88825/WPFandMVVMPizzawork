using PizzaWork.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.DataLayer.EFContext
{
    public partial class PizzaWorkContext : DbContext
    {
        public PizzaWorkContext(string name) : base(name)
        {
            Database.SetInitializer(new PizzaWorkInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>()
        //        .HasRequired(r => r.StartSpot)
        //        .WithMany(s => s.OrdersStart)
        //        .HasForeignKey(r=>r.OrderSpotId);

        //    modelBuilder.Entity<Order>()
        //        .HasOptional(r => r.EndSpot)
        //        .WithMany(s => s.OrdersEnd)
        //        .HasForeignKey(r => r.EndSpotId);

        //    base.OnModelCreating(modelBuilder);
        //}

        //Отражение таблиц БД на свойства с типом DbSet
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaType> PizzaTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Spot> Spots { get; set; }
    }
}
