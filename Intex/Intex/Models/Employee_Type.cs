using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Employee_Type")]
    public class Employee_Type
    {
        [Key]
        public int typeID { get; set; }
        public String empType { get; set; }
    }
}