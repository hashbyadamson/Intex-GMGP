using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Required (ErrorMessage = "This field is required")]
        public int orderID { get; set; }
        public String comment { get; set; }
        [Required]
        public bool resultsMailed { get; set; }
        public String summaryReport { get; set; }
        [Required (ErrorMessage ="Please enter a Date")]
        [RegularExpression(@"\d{2,2}/\d{2,2}/\d{4,4} \d{2,2}:\d{2,2}:\d{2,2}", ErrorMessage ="Incorrect Syntax. Please enter DD/MM/YYYY 00:00:00")]
        public DateTime comfirmationSenddatetime { get; set; }

        [ForeignKey("Order_Progress")]
        [Required]
        public String orderProgress { get; set; }
        public virtual Order_Progress Order_Progress { get; set; }

        [ForeignKey("Employee")]
        [Required (ErrorMessage ="Please include an Employee on the Order")]
        public int employeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Data_Report")]
        public int? dataReportID { get; set; }
        public virtual Data_Report Data_Report { get; set; }

        [ForeignKey("Client")]
        [Required(ErrorMessage ="Plase include a Client on the Order")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

    }
}