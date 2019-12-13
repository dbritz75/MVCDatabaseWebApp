using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp.Models
{
    public class EmployeeModel
    {
        [Display(Name ="Employee ID:")]
        [Range(1000,9999,ErrorMessage="Invalid employee ID format. Must use 1000-9999")]
        public int employeeID { get; set; }


        [Display(Name = "First Name:")]
        [Required(ErrorMessage ="You must enter a first name.")]
        public string firstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "Come on this isn't the 12th century. Everyone has a last name.")]
        public string lastName { get; set; }

        [Display(Name = "Email:")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter your email address so we know where to send you spam. Ooops, shouldn't have said that.")]
        public string emailAddress { get; set; }

        
        [Display(Name = "That's an awesome email address. Pray type it again!")]
        [Compare("emailAddress",ErrorMessage ="Emails don't match. Come on, try again.")]
        public string confirmEmail { get; set; }


        [Display(Name = "Password:")]
        [StringLength(25,MinimumLength =5,ErrorMessage ="Please make sure your password is between 5 & 25 characters.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm password:")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage ="I know you just typed in your password but they don't match, so PLEASE do it again. Thx.")]
        public string confirmPwd { get; set; }
    }
}