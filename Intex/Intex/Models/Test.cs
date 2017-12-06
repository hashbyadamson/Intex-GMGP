using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int testID { get; set; }
        public String testName { get; set; }
        public String equipmentReq { get; set; }
        public String procedures { get; set; }
        public decimal basePrice { get; set; }
        public decimal testPrice { get; set; }
    }
}