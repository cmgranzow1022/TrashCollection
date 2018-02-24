namespace TrashCollection.Migrations.TCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressId" });
            AddColumn("dbo.Customers", "Street", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "ZipCode", c => c.String());
            DropColumn("dbo.Customers", "AddressId");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "ZipCode");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Street");
            CreateIndex("dbo.Customers", "AddressId");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
    }
}
