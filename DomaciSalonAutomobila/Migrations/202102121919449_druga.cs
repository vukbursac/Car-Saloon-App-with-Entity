namespace DomaciSalonAutomobila.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class druga : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Automobiles", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.Automobiles", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Manufacturers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Salons", "PIB", c => c.String(nullable: false));
            AlterColumn("dbo.Salons", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Salons", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Salons", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Salons", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salons", "Address", c => c.String());
            AlterColumn("dbo.Salons", "City", c => c.String());
            AlterColumn("dbo.Salons", "Country", c => c.String());
            AlterColumn("dbo.Salons", "Name", c => c.String());
            AlterColumn("dbo.Salons", "PIB", c => c.String());
            AlterColumn("dbo.Manufacturers", "City", c => c.String());
            AlterColumn("dbo.Manufacturers", "Country", c => c.String());
            AlterColumn("dbo.Manufacturers", "Name", c => c.String());
            AlterColumn("dbo.Automobiles", "Color", c => c.String());
            AlterColumn("dbo.Automobiles", "Model", c => c.String());
        }
    }
}
