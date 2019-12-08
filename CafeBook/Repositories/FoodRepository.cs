using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeBook.Data;
using CafeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Repositories
{
    public class FoodRepository:IFoodRepository
    {
        readonly CafeBookContext _context;
        public FoodRepository(CafeBookContext context)
        {
            _context = context;
        }

        public void Add(Food food)
        {
            _context.Add(food);
        }

        public void Update(Food food)
        {
            _context.Update(food);
        }

        public void Delete(Food food)
        {
            _context.Remove(food);
        }

        public bool Exist(int id)
        {
            return _context.Book.Any(m => m.Id == id);
        }

        public Task<List<Food>> GetFoods()
        {
            return _context.Food.ToListAsync();
        }

        public Task<Food> GetFoodDetail(int? id)
        {
            return _context.Food.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<FoodType> GetFoodType()
        {
            return _context.FoodType;
        }
    }
}
