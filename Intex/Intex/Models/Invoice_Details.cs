using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Invoice_Details")]
    public class Invoice_Details
    {
        [Key]
        public int invoiceLine { get; set; }

        [ForeignKey("Invoice")]
        public virtual int invoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        [ForeignKey("Test")]
        public virtual int testID { get; set; }
        public virtual Test Test { get; set; }
    }
}