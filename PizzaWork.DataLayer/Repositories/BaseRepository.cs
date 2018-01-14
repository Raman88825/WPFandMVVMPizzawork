using PizzaWork.DataLayer.EFContext;
using PizzaWork.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaWork.DataLayer.Repositories
{
    public abstract class BaseRepository<T> where T: class
    {
        protected PizzaWorkContext context;
        protected DbSet<T> table;

        public BaseRepository(PizzaWorkContext context)
        {
            this.context = context;
        }

        public virtual void Create(T t)
        {
            table.Add(t);
        }

        public virtual void Delete(int id)
        {
            var entity = table.Find(id);
            if (entity != null)
            {
                table.Remove(entity);
            }
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return table.Where(predicate);
        }

        public virtual T Get(int id)
        {
            return table.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return table;
        }

        public virtual void Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
