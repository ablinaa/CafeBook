using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CafeBook.Data;
using CafeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly CafeBookContext _context;

        public UserRepository(CafeBookContext cafeBookContext)
        {
            _context = cafeBookContext;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public bool Exists(string id)
        {
            return _context.User.Any(u => u.Id == id);
        }

        public Task<List<User>> GetAllUser()
        {
            return _context.User.ToListAsync();
        }

        public Task<User> GetDetails(string? id)
        {
            return _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate)
        {
            return _context.User.Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
