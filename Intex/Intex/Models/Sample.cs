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
        [Key]
        public int LTNumber { get; set; }
        [Key]
        public int sequenceCode { get; set; }
        public int quantityMG { get; set; }

        [ForeignKey("Compound")]
        public virtual int CompoundID { get; set; }
        public virtual Compound Compound { get; set; }

        }
}