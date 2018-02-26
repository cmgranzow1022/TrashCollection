namespace TrashCollection.Migrations.TCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingvacationtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "VacationStart", c => c.String());
            AddColumn("dbo.Customers", "VacationEnd", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "VacationEnd");
            DropColumn("dbo.Customers", "VacationStart");
        }
    }
}
