﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeBook.Models
{
    public class RentSchedule
    {
        public int Id { get; set; }
        public DateTime DateOfRent { get; set; }
        public DateTime DateOfReturn { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
