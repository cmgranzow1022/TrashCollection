namespace TrashCollection.Migrations.TCMigrations
{
    using Data;
    using Models.TrashCollector;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrashCollection.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollection.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\TCMigrations";
        }

        protected override void Seed(TrashCollection.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.Addresses.AddOrUpdate(
                t => t.AddressId, DummyData.getAddress(context).ToArray());
            context.SaveChanges();

            context.Customers.AddOrUpdate(
                p => new { p.FirstName, p.LastName }, DummyData.getCustomers().ToArray());
        }

    }
    }

