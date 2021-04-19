namespace DomaciSalonAutomobila.Migrations
{
    using DomaciSalonAutomobila.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DomaciSalonAutomobila.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DomaciSalonAutomobila.Models.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Salons.AddOrUpdate(
              
                new Salon() { Id = 1, Name = "Prvi", PIB = "12344", Address = "adresa1", Country = "Srbija", City = "Beograd"},
                new Salon() { Id = 2, Name = "Drugi", PIB = "12345", Address = "adresa2", Country = "Srbija", City = "Novi Sad" },
                new Salon() { Id = 3, Name = "Treci", PIB = "12346", Address = "adresa3", Country = "Srbija", City = "Nis"},
                new Salon() { Id = 4, Name = "Cetvrti", PIB = "12347", Address = "adresa4", Country = "Srbija", City = "Kragujevac" }
            );
            context.SaveChanges();

            context.Manufacturers.AddOrUpdate(
            
                new Manufacturer() { Id = 1, Name = "Fiat", City = "Milano", Country = "Italy"},
                new Manufacturer() { Id = 2, Name = "Volkswagen", City = "Wolfsburg", Country = "Germany" },
                new Manufacturer() { Id = 3, Name = "BMW", City = "Munich", Country = "Germany" },
                new Manufacturer() { Id = 4, Name = "Zastava", City = "Kragujevac", Country = "Serbia" }

            );
            context.SaveChanges();

            context.Automobiles.AddOrUpdate(
            
                new Automobile() { Id = 1, Model = "Stilo", Color = "Black", Power = 1600, Year = 2003, ManufacturerId = 1, SalonId = 3},
                new Automobile() { Id = 2, Model = "X5", Color = "Black", Power = 3000, Year = 2012, ManufacturerId = 3, SalonId = 4 },
                new Automobile() { Id = 3, Model = "Passat", Color = "Grey", Power = 1900, Year = 2010, ManufacturerId = 2, SalonId = 3 },
                new Automobile() { Id = 4, Model = "Polo", Color = "Black", Power = 1600, Year = 2003, ManufacturerId = 2, SalonId = 3 },
                new Automobile() { Id = 5, Model = "500L", Color = "Red", Power = 1300, Year = 2010, ManufacturerId = 1, SalonId = 2 },
                new Automobile() { Id = 6, Model = "101", Color = "Orange", Power = 1000, Year = 2001, ManufacturerId = 4, SalonId = 1 }

            );
            context.SaveChanges();

            context.Connections.AddOrUpdate(
                
                new Connection() { Id = 1, ManufacturerId = 2, SalonId = 3 },
                new Connection() { Id = 2, ManufacturerId = 1, SalonId = 2 },
                new Connection() { Id = 3, ManufacturerId = 4, SalonId = 1 },
                new Connection() { Id = 4, ManufacturerId = 3, SalonId = 4 },
                new Connection() { Id = 5, ManufacturerId = 2, SalonId = 4 },
                new Connection() { Id = 6, ManufacturerId = 1, SalonId = 3 },
                new Connection() { Id = 7, ManufacturerId = 4, SalonId = 2 }
            );
            context.SaveChanges();
        }
    }
}
