namespace TrashCollection.Migrations.TCMigrations
{
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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

         

            Customer[] customers = DummyData.getCustomers(context).ToArray();
            for (int i = 0; i < customers.Length; i++)
            {
                context.Customers.AddOrUpdate(customers[i]);
                context.SaveChanges();
            }

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                if (!roleManager.RoleExists("Admin"))
                    roleManager.Create(new IdentityRole("Admin"));

                if (!roleManager.RoleExists("Guest"))
                    roleManager.Create(new IdentityRole("Guest"));


                if (!roleManager.RoleExists("Employee"))
                    roleManager.Create(new IdentityRole("Employee"));

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                if (userManager.FindByEmail("a@a.com") == null)
                {
                    var user = new ApplicationUser
                    {
                        Email = "a@a.com",
                        UserName = "a@a.com",
                    };
                    var result = userManager.Create(user, "Password");
                    if (result.Succeeded)
                        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
                }
                if (userManager.FindByEmail("g@g.com") == null)
                {
                    var user = new ApplicationUser
                    {
                        Email = "g@g.com",
                        UserName = "g@g.com",
                    };
                    var result = userManager.Create(user, "Password");
                    if (result.Succeeded)
                        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Guest");
                }
                if (userManager.FindByEmail("e@e.com") == null)
                {
                    var user = new ApplicationUser
                    {
                        Email = "e@e.com",
                        UserName = "e@e.com",
                    };
                    var result = userManager.Create(user, "Password");
                    if (result.Succeeded)
                        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Employee");
                }

            }
        }
    }





