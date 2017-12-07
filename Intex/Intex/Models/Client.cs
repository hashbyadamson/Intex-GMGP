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
        [Required(ErrorMessage ="This field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String clientFirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String clientLastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public String addressLine1 { get; set; }
        public String addressLine2 { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String clientCity { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^\D{2}$", ErrorMessage = "Please enter in the format XX")]
        public String clientState { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Please enter a valid 5 digit zipcode.")]
        public String clientZip { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public String clientPhone { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public String clientCountry { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^0{1}$", ErrorMessage ="Sorry you can't put your discount higher than 0")]
        public decimal clientDiscount { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage ="Please enter a valid Email Address")]
        public String clientEmail { get; set; }
        [Required(ErrorMessage = "This field is required")]

        [ForeignKey("Login")]
        public virtual String username { get; set; }
        public virtual Login Login { get; set; }

    }
}