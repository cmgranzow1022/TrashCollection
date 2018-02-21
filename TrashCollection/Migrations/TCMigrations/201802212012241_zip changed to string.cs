namespace TrashCollection.Migrations.TCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zipchangedtostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.Int(nullable: false));
        }
    }
}
