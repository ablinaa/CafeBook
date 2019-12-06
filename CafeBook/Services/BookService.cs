using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAndSave(Book book)
        {
            _repository.Add(book);
        }

        public async Task Update(Book book)
        {
            _repository.Update(book);
            await _repository.Save();
        }

        public async Task Delete(Book book)
        {
            _repository.Delete(book);
            await _repository.Save();
        }

        public bool Exist(int id)
        {
            return _repository.Exists(id);
        }

        public async Task<List<Book>> GetAllBook()
        {
            return await _repository.GetAllBook();
        }

        public async Task<Book> GetDetails(int? id)
        {
            return await _repository.GetDetails(id);
        }

        public DbSet<BookType> GetBookTypes()
        {
            return _repository.GetBookTypes();
        }
    }
}
