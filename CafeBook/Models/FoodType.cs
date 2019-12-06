using System;
using System.Collections.Generic;

namespace CafeBook.Models
{
    public class FoodType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public List<Food> Foods { get; set; }
    }
}
