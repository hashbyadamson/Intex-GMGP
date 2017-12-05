using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        public int clientID { get; set; }
        public String clientFirstName { get; set; }
        public String clientLastName { get; set; }
        public String addressLine1 { get; set; }
        public String addressLine2 { get; set; }
        public String clientCity { get; set; }
        public String clientState { get; set; }
        public String clientZip { get; set; }
        public String clientPhone { get; set; }
        public String clientCountry { get; set; }
        public String clientDiscount { get; set; }
        public String clientEmail { get; set; }

        [ForeignKey("Login")]
        public virtual String username { get; set; }
        public virtual Login Login { get; set; }

    }
}