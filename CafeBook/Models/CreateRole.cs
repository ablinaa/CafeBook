using System;
using System.ComponentModel.DataAnnotations;

namespace CafeBook.Models
{
    public class CreateRole
    {
       
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
