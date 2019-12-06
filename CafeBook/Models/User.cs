using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CafeBook.Models
{
    public class User
    {
        public int Id { get; set; }

        [Remote(action:"VerifyLogin",controller:"User")]
        public string Login { get; set; }
        public string Password { get; set; }


        public Profile Profile { get; set; }

        public Identity Identity { get; set; }

        public List<RentSchedule> RentSchedule { get; set; }
    }
}
