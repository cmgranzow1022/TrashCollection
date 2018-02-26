using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrashCollection.Models;
using TrashCollection.Models.TrashCollector;

namespace TrashCollection.Data
{
    public class DummyData
    {

        public static List<Customer> getCustomers(ApplicationDbContext context)
        {
            List<Customer> customers = new List<Customer>()
            {
            new Customer()
            {
                CustomerId = 1,
                FirstName = "Rick",
                LastName= "Hintz",
                PhoneNumber= "414-456-7890",
                EmailAddress = "rh@rh.com",
                PickUpDay = "Monday",
                Street = "2835 S Tammy Ln",
                City = "New Berlin",
                State = "WI",
                ZipCode = "53151",
                VacationStart = null,
                VacationEnd = null,
            },
            new Customer()
            {
                CustomerId = 2,
                FirstName = "Christine",
                LastName= "Granzow",
                PhoneNumber= "414-234-2345",
                EmailAddress = "cg@cg.com",
                PickUpDay = "Monday",
                Street = "1022 S 121st St",
                City = "West Allis",
                State = "WI",
                ZipCode = "53214",
                VacationStart = null,
                VacationEnd = null,
            },
            new Customer()
            {
                CustomerId = 3,
                FirstName = "Katie",
                LastName= "Steingraber",
                PhoneNumber= "262-456-6544",
                EmailAddress = "ks@ks.com",
                PickUpDay = "Tuesday",
                Street = "W5551 Colin St",
                City = "Appleton",
                State = "WI",
                ZipCode = "54915",
                VacationStart = null,
                VacationEnd = null,
            },
            };
            return customers;
        }


             
    }
}
