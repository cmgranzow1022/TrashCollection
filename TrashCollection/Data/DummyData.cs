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

        public static List<Customer> getCustomers()
        {
            List<Customer> customers = new List<Customer>()
            {
            new Customer()
            {
                FirstName = "Christine",
                LastName= "Granzow",
                PhoneNumber= "414-456-7890",
                AddressId = 1,
            },
            new Customer()
            {
                FirstName = "Katie",
                LastName= "Steingraber",
                PhoneNumber= "414-234-2345",
                AddressId = 2,
            },
            new Customer()
            {
                FirstName = "Richard",
                LastName= "Hintz",
                PhoneNumber= "262-456-6544",
                AddressId = 3,
            },
            };
            return customers;
        }

        public static List<Address> getAddress(ApplicationDbContext context)
        {
            List<Address> addresses = new List<Address>()
            {
                new Address
                {

                    Street = "1022 S 121st St",
                    City = "West Allis",
                    State = "WI",
                    ZipCode = 53214,
                },
                new Address
                {
 
                    Street = "W5551 Colin St",
                    City = "Appleton",
                    State = "WI",
                    ZipCode = 54915,
                },
                new Address
                {

                    Street = "2835 S Tammy Ln",
                    City = "New Berlin",
                    State = "WI",
                    ZipCode = 53151,
                },



              };
            return addresses;
        }
    




    }
}