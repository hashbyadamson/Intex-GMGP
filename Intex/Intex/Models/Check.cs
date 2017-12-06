using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Check")]
    public class Check
    {
        [Key]
        public int checkID { get; set; }
        public String checkNumber { get; set; }
        public DateTime checkDate { get; set; }
        public DateTime dateReceived { get; set; }
        public DateTime depositDate { get; set; }
        public decimal checkAmount { get; set; }


        [ForeignKey("Client")]
        public virtual int? clientID { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("Deposit_Slip")]
        public virtual int? depositSlipNumber { get; set; }
        public virtual Deposit_Slip Deposit_Slip { get; set; }

    }
}