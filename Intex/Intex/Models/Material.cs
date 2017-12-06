using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int materialID { get; set; }
        public String materialName { get; set; }
        public decimal materialCost { get; set; }

    }
}