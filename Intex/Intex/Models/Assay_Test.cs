using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Assay_Test")]
    public class Assay_Test
    {
        [Key, Column(Order = 0)]
        public int testID { get; set; }
        [Key, Column(Order = 1)]
        public int assayID { get; set; }

        public bool isTestRequired { get; set; }
    }
}