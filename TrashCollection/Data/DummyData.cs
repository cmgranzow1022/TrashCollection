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
                FirstName = "Christine",
                LastName= "Granzow",
                PhoneNumber= "414-456-7890",
                Street = "2835 S Tammy Ln",
                City = "New Berlin",
                State = "WI",
                ZipCode = "53151",
            },
            new Customer()
            {
                CustomerId = 2,
                FirstName = "Katie",
                LastName= "Steingraber",
                PhoneNumber= "414-234-2345",
                Street = "1022 S 121st St",
                City = "West Allis",
                State = "WI",
                ZipCode = "53214",
            },
            new Customer()
            {
                CustomerId = 3,
                FirstName = "Richard",
                LastName= "Hintz",
                PhoneNumber= "262-456-6544",
                Street = "W5551 Colin St",
                City = "Appleton",
                State = "WI",
                ZipCode = "54915", 
            },
            };
            return customers;
        }


             
    }
}
