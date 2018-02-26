namespace TrashCollection.Migrations.TCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrouteview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RouteViewModels", "CustomerId", "dbo.Customers");
            DropIndex("dbo.RouteViewModels", new[] { "CustomerId" });
            DropTable("dbo.RouteViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RouteViewModels",
                c => new
                    {
                        Routeid = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Routeid);
            
            CreateIndex("dbo.RouteViewModels", "CustomerId");
            AddForeignKey("dbo.RouteViewModels", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
