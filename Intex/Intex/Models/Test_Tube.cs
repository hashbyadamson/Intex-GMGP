using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{

    [Table("Test_Tube")]
    public class Test_Tube
    {
        [Key]
        public int testTubeNumber { get; set; }
        public int LTNumber{ get; set; }
        public decimal concentration_mg { get; set; }

        [ForeignKey("Test")]
        public virtual int testID { get; set; }
        public virtual Test Test { get; set; }

    }
}