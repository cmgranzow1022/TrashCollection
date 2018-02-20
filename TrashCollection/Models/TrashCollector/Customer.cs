using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrashCollection.Models.TrashCollector
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
        
    }
}