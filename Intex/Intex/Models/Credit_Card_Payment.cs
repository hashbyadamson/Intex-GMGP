using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Credit_Card_Payment")]
    public class Credit_Card_Payment
    {
        [Key]
        public int creditCardPaymentNum { get; set; }
        public DateTime ccPaymentDate { get; set; }
        public decimal ccPaymentAmount { get; set; }
        public DateTime ccPaymentProcessedDate { get; set; }

        [ForeignKey("Client")]
        public virtual int clientID { get; set; }
        public virtual Client Client { get; set; }
    }
}