using System;
using System.ComponentModel.DataAnnotations;
using CafeBook.Attributes;

namespace CafeBook.Models
{
    public class Identity
    {
        public int Id { get; set; }

        [Required]
        [IdentityAttribute("12","The IIN number must contain 12 numbers")]
        public string IIN { get; set; }
        public string CardNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string IssuedBy { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
