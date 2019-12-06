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
    public class BookRepository : IBookRepository
    {
        readonly CafeBookContext _context;

        public BookRepository(CafeBookContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Add(book);
        }

        public void Delete(Book book)
        {
            _context.Remove(book);
        }

        public bool Exists(int id)
        {
            return _context.Book.Any(b => b.Id == id);
        }

        public Task<List<Book>> GetAllBook()
        {
            return _context.Book.Include(b=>b.BookType).ToListAsync();
        }

        public Task<Book> GetDetails(int? id)
        {
            return _context.Book.Include(b => b.BookType)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<List<Book>> GetBooks(Expression<Func<Book, bool>> predicate)
        {
            return _context.Book.Include(b => b.BookType)
                .Where(predicate).ToListAsync();
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Book book)
        {
            _context.Update(book);
        }

        public DbSet<BookType> GetBookTypes()
        {
            return _context.BookType;
        }
    }
}
