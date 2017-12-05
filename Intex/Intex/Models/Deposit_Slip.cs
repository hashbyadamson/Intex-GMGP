using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Deposit_Slip")]
    public class Deposit_Slip
    {
        [Key]
        public int depositSlipNumber { get; set; }

        [ForeignKey("Employee")]
        public virtual int employeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}