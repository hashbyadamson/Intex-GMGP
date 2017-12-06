using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Compound_Weighing_and_Dispensing_Log_Entry")]
    public class Compound_Weighing_and_Dispensing_Log_Entry
    {
        [Key]
        public int entryID { get; set; }
        public decimal actualWeight_mg { get; set; }
        public decimal MTD_mg { get; set; }

        [ForeignKey("Compound_Receipt_Log_Entry")]
        public virtual int LTNumber { get; set; }
        public virtual Compound_Receipt_Log_Entry Compound_Receipt_Log_Entry { get; set; }
    }
}