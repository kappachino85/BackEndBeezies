using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackEndBeezies.Models.Requests.Member
{
    public class RegistrationAddRequest
    {
        [Required/*( ErrorMessage = "An Email address is required" )*/]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$", ErrorMessage = "Invalid Email Format")]
        /*ErrorMessage = "Email is required and must be properly formatted."*/
        public string Email { get; set; }

        [Required/*( ErrorMessage = "" )*/]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Password MUST contain: an uppercase, a lowercase, numeric digit & a special character")]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name is too Short (Max Length 20 characters)")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last Name is too Short (Max Length 20 characters)")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}