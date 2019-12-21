using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CafeBook.Models;

namespace CafeBook.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        bool Exists(string id);
        Task Save();
        Task<List<User>> GetAllUser();
        Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate);
        Task<User> GetDetails(string? id);
    }
}
