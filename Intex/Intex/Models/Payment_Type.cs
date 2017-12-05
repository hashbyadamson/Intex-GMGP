using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table ("Payment_Type")]
    public class Payment_Type
    {
        [Key]
        public int paymentTypeCode { get; set; }
        public string paymentDescription { get; set; }

    }
}