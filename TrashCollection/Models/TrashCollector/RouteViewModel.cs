using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TrashCollection.Models.TrashCollector;

namespace TrashCollection.Models
{
    public class RouteViewModel
    {
        [Key]
        public int Routeid { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
   
    }
    
}