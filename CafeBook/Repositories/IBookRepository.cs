using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CafeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Delete(Book book);
        bool Exists(int id);
        Task Save();
        Task<List<Book>> GetAllBook();
        Task<List<Book>> GetBooks(Expression<Func<Book, bool>> predicate);
        Task<Book> GetDetails(int? id);
        DbSet<BookType> GetBookTypes();
    }
}
