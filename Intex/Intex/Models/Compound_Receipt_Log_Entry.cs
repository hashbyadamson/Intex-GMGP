using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Compound_Receipt_Log_Entry")]
    public class Compound_Receipt_Log_Entry
    {
        [Key]
        public int LTNumber { get; set; }
        public DateTime dueDate { get; set; }
        public decimal weight { get; set; }
        public decimal molecularMass { get; set; }
        public int confirmationSent { get; set; }

        [ForeignKey("Employee")]
        public virtual int employeeID { get; set; }
        public virtual Employee Employee { get; set; }

    }
}