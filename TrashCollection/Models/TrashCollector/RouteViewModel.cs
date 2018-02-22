using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrashCollection.Models.TrashCollector;

namespace TrashCollection.Models
{
    public class RouteViewModel
    {
            [Key]
            public int id { get; set; }
            [Required]
            public int Customerid { get; set; }
            public virtual Customer Customer { get; set; }
            [Required]
            public int Employeeid { get; set; }
            //public virtual Employee Employee { get; set; }
    }
}