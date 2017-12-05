using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Order_Progress")]
    public class Order_Progress
    {
        [Key]
        public String orderProgress { get; set; }

    }
}