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
    public class ShipmentsRepository
    {
        private MyDbContext context = null;

        public ShipmentsRepository()
        {
            context = new MyDbContext();
        }

        public List<Shipment> GetAll(Expression<Func<Shipment, bool>> filter)
        {
            IQueryable<Shipment> query = context.Shipments;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public void Insert(Shipment item)
        {
            context.Shipments.Add(item);

            context.SaveChanges();
        }

        public void Update(Shipment item)
        {
            DbEntityEntry entry = context.Entry(item);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public Shipment GetById(int id)
        {
            return context.Shipments
                            .Where(i => i.Id == id)
                            .FirstOrDefault();
        }

        public Shipment GetFirstOrDefault(Expression<Func<Shipment, bool>> filter)
        {
            return context.Shipments
                      .Where(filter)
                      .FirstOrDefault();
        }

        public void Delete(int id)
        {
            Shipment item = GetById(id);
           
            if (item != null)
            {
                context.Shipments.Remove(item);
                context.SaveChanges();
            }
        }
    }
}