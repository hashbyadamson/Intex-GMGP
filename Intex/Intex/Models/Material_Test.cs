using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    [Table("Material_Test")]
    public class Material_Test
    {
        [Key, Column(Order = 0)]
        public int materialID { get; set; }
        [Key, Column(Order = 1)]
        public int testID { get; set; }

        public String amountReq { get; set; }
    }
}