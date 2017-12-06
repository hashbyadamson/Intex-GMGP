using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class PastOrders
    {
        [Key]
        public int orderID { get; set; }
        public string comment { get; set; }
        public string summaryReport { get; set; }
        public bool resultsMailed { get; set; }
        public string orderProgress { get; set; }

        [ForeignKey("Client")]
        public virtual int clientID { get; set; }
        public virtual Client Client { get; set; }
    }
}