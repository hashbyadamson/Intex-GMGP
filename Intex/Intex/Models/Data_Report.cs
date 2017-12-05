using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Data_Report")]
    public class Data_Report
    {
        [Key]
        public int dataReportID { get; set; }
        public String rawData { get; set; }
    }
}