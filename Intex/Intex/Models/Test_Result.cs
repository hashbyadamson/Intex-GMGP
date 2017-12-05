using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Test_Result")]
    public class Test_Result
    {
        [Key]
        public int testTubeNumber { get; set; }

        [ForeignKey("Order")]
        public virtual int orderID { get; set; }
        public virtual Order Order { get; set; }

        [ForeignKey("Test")]
        public virtual int testID { get; set; }
        public virtual Test Test { get; set; }

        [ForeignKey("Data_Report")]
        public virtual int? dataReportID { get; set; }
        public virtual Data_Report Data_Report { get; set; }
    }
}