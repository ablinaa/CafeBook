using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;

namespace CafeBook.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAndSave(User user)
        {
            _repository.Add(user);
            await _repository.Save();
        }

        public async Task Update(User user)
        {
            _repository.Update(user);
            await _repository.Save();
        }

        public async Task Delete(User user)
        {
            _repository.Delete(user);
            await _repository.Save();
        }

        //public async Task<User> GetDetails(int id)
        //{
        //    return await _repository.GetDetails(id);
        //}

        public bool Exist(string id)
        {
            return _repository.Exists(id);
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _repository.GetAllUser();
        }

        internal async Task<User> GetDetails(string? id)
        {
            return await _repository.GetDetails(id);
        }
    }
}
