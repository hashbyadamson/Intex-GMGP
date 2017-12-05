using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key, Column(Order = 0)]
        public int LTNumber { get; set; }
        [Key, Column(Order = 1)]
        public int sequenceCode { get; set; }
        public int quantityMG { get; set; }

        [ForeignKey("Compound")]
        public virtual int CompoundID { get; set; }
        public virtual Compound Compound { get; set; }

        }
}