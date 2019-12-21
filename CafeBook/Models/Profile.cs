using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeBook.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
