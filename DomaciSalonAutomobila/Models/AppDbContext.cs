using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DomaciSalonAutomobila.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public AppDbContext() : base("name=Salon") { }
    }
}