﻿using System;
namespace CafeBook.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
