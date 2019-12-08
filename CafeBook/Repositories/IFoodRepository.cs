using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Repositories
{
    public interface IFoodRepository
    {
        void Add(Food food);
        void Update(Food food);
        void Delete(Food food);
        Task Save();
        Task<List<Food>> GetFoods();
        Task<Food> GetFoodDetail(int? id);
        bool Exist(int id);
        DbSet<FoodType> GetFoodType();
    }
}
