using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Services
{
    public class FoodService
    {
        private readonly IFoodRepository _repo;
        public FoodService(IFoodRepository repo)
        {
            _repo = repo;
        }

        // GET: Roles
        public async Task<List<Food>> GetFoods()
        {
            return await _repo.GetFoods();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Food> DetailsFood(int? id)
        {
            return await _repo.GetFoodDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool FoodExis(int id)
        {
            return _repo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Food food)
        {
            _repo.Add(food);
            await _repo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Food food)
        {
            _repo.Update(food);
            await _repo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Food food)
        {
            _repo.Delete(food);
            await _repo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }

        public DbSet<FoodType> getFoodType()
        {
            return _repo.GetFoodType();
        }
    }
}
