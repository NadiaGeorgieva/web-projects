using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Vechicles.Entities;

namespace Vechicles.Repositories
{
    public class DriversRepository
    {
        private MyDbContext context = null;

        public DriversRepository()
        {
            context = new MyDbContext();
        }

        public List<Driver> GetAll(Expression<Func<Driver, bool>> filter)
        {
            IQueryable<Driver> query = context.Drivers;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public void Insert(Driver item)
        {
            context.Drivers.Add(item);

            context.SaveChanges();
        }

        public void Update(Driver item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public Driver GetById(int id)
        {
            return context.Drivers
                            .Where(i => i.Id == id)
                            .FirstOrDefault();
        }

        public Driver GetFirstOrDefault(Expression<Func<Driver, bool>> filter)
        {
            return context.Drivers
                      .Where(filter)
                      .FirstOrDefault();
        }

        public void Delete(int id)
        {
            Driver item = GetById(id);

            if (item != null)
            {
                context.Drivers.Remove(item);
                context.SaveChanges();
            }
        }
    }
}