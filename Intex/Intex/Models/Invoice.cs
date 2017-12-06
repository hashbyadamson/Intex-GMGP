using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int invoiceID { get; set; }
        public DateTime paymentDue { get; set; }
        public DateTime paymentEarly { get; set; }
        public decimal earlyPaymentDisc { get; set; }


        [ForeignKey("Order")]
        public virtual int orderID { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Payment_Type")]
        public virtual int? paymentTypeCode { get; set; }
        public virtual Payment_Type Payment_Type { get; set; }

        [ForeignKey("Credit_Card_Payment")]
        public int? creditCardPaymentNum { get; set; }
        public virtual Credit_Card_Payment Credit_Card_Payment { get; set; }

    }
}