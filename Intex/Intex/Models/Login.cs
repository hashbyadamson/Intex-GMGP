using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public String username { get; set; }
        public String password { get; set; }
    }
}