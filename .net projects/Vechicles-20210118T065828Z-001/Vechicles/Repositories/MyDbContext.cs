using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vechicles.Entities;

namespace Vechicles.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Reciever> Recievers { get; set; }
        public DbSet<Share> Shares { get; set; }
        public MyDbContext()
           : base("Server=DESKTOP-5OETMPC\\EXPRESS;Database=Vechicles;Trusted_Connection=true;")
        {
            Users = this.Set<User>();
            Drivers = this.Set<Driver>();
            Cars = this.Set<Car>();
            Shipments = this.Set<Shipment>();
            Recievers = this.Set<Reciever>();
            Shares = this.Set<Share>();
        }
    }
}