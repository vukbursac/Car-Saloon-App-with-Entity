namespace DomaciSalonAutomobila.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prva : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automobiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Power = c.Double(nullable: false),
                        Color = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                        SalonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Salons", t => t.SalonId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.SalonId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PIB = c.String(),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufacturerId = c.Int(nullable: false),
                        SalonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.Salons", t => t.SalonId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.SalonId);
            
            CreateTable(
                "dbo.SalonManufacturers",
                c => new
                    {
                        Salon_Id = c.Int(nullable: false),
                        Manufacturer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Salon_Id, t.Manufacturer_Id })
                .ForeignKey("dbo.Salons", t => t.Salon_Id, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id, cascadeDelete: true)
                .Index(t => t.Salon_Id)
                .Index(t => t.Manufacturer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Connections", "SalonId", "dbo.Salons");
            DropForeignKey("dbo.Connections", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.SalonManufacturers", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.SalonManufacturers", "Salon_Id", "dbo.Salons");
            DropForeignKey("dbo.Automobiles", "SalonId", "dbo.Salons");
            DropForeignKey("dbo.Automobiles", "ManufacturerId", "dbo.Manufacturers");
            DropIndex("dbo.SalonManufacturers", new[] { "Manufacturer_Id" });
            DropIndex("dbo.SalonManufacturers", new[] { "Salon_Id" });
            DropIndex("dbo.Connections", new[] { "SalonId" });
            DropIndex("dbo.Connections", new[] { "ManufacturerId" });
            DropIndex("dbo.Automobiles", new[] { "SalonId" });
            DropIndex("dbo.Automobiles", new[] { "ManufacturerId" });
            DropTable("dbo.SalonManufacturers");
            DropTable("dbo.Connections");
            DropTable("dbo.Salons");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Automobiles");
        }
    }
}
