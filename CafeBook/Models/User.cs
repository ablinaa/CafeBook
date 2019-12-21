using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeBook.Models
{
    public class User:IdentityUser
    {
        
        [Required]
        [EmailAddress]
        [Remote(action:"VerifyLogin",controller:"User")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Profile Profile { get; set; }

        public Identity Identity { get; set; }

        public List<RentSchedule> RentSchedule { get; set; }
    }
}
