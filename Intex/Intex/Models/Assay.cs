using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Intex.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        public int assayID { get; set; }
        public String assayDescription { get; set; }
        public int daysToComplete { get; set; }


    }
}