﻿using System;
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
        public int orderID { get; set; }
        public String comment { get; set; }
        public bool resultsMailed { get; set; }
        public String summaryReport { get; set; }
        public DateTime comfirmationSenddatetime { get; set; }

        [ForeignKey("Order_Progress")]
        public String orderProgress { get; set; }
        public virtual Order_Progress Order_Progress { get; set; }

        [ForeignKey("Employee")]
        public int employeeID { get; set; }
        public virtual Employee Employee { get; set; }

        [ForeignKey("Data_Report")]
        public int? dataReportID { get; set; }
        public virtual Data_Report Data_Report { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }

    }
}