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
        Task Save();
        Task<List<Book>> GetAll();
        Task<Book> GetDetail(int? id);
        bool Exist(int id);
        DbSet<BookType> GetBookType();
    }
}
