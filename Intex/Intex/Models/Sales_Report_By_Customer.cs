using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class Sales_Report_By_Customer
    {
        [Key]
        public string clientFirstName { get; set; }
        public string clientLastName { get; set; }
        public decimal? basePrice { get; set; }
        public decimal? testPrice { get; set; }

    }
}