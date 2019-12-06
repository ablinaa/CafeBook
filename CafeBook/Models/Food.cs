using System;
namespace CafeBook.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public string Volume { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
    }
}
