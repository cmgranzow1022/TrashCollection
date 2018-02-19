namespace TrashCollection.Migrations.TCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDataTypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "Address_AddressId" });
            DropColumn("dbo.Customers", "AddressId");
            RenameColumn(table: "dbo.Customers", name: "Address_AddressId", newName: "AddressId");
            AlterColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "AddressId");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressId" });
            AlterColumn("dbo.Customers", "AddressId", c => c.Int());
            AlterColumn("dbo.Customers", "AddressId", c => c.String());
            RenameColumn(table: "dbo.Customers", name: "AddressId", newName: "Address_AddressId");
            AddColumn("dbo.Customers", "AddressId", c => c.String());
            CreateIndex("dbo.Customers", "Address_AddressId");
            AddForeignKey("dbo.Customers", "Address_AddressId", "dbo.Addresses", "AddressId");
        }
    }
}
