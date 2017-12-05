using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int employeeID { get; set; }
        public String employeeFirstName { get; set; }
        public String employeeLastName { get; set; }
        public String employeeEmail { get; set; }
        public String employeePhone { get; set; }


        [ForeignKey("Employee_Type")]
        public virtual int typeID { get; set; }
        public virtual Employee_Type Employee_Type { get; set; }

        [ForeignKey("Login")]
        public virtual String username { get; set; }
        public virtual Login Login { get; set; }
    }
}