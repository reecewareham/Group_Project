using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project.Models
{
    public class Users
    {
        public int Id { get; set; }
        

        [Display(Name = "User ID")] 
        public string UserID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name ="Password")]
        public string Password { get; set;}

        [Display(Name ="Role")]
        public string Role { get; set; }
    }
}
