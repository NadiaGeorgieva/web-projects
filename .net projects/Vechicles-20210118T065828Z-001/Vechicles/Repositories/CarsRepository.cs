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
    public class CarsRepository
    {
        private MyDbContext context = null;

        public CarsRepository()
        {
            context = new MyDbContext();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            IQueryable<Car> query = context.Cars;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public void Insert(Car item)
        {
            context.Cars.Add(item);

            context.SaveChanges();
        }

        public void Update(Car item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public Car GetById(int id)
        {
            return context.Cars
                            .Where(i => i.Id == id)
                            .FirstOrDefault();
        }

        public Car GetFirstOrDefault(Expression<Func<Car, bool>> filter)
        {
            return context.Cars
                      .Where(filter)
                      .FirstOrDefault();
        }

        public void Delete(int id)
        {
            Car item = GetById(id);

            if (item != null)
            {
                context.Cars.Remove(item);
                context.SaveChanges();
            }
        }
    }
}