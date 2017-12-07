using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Intex.Models
{
    public class QuoteForm
    {
        [Required]
        [Display(Name ="Compound Name")]
        public string compoundName { get; set; }
        [Required]
        [Display(Name = "Number of Samples")]
        public int numSamples { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string inputEmail { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Comments")]
        public string comments { get; set; }

    }
}