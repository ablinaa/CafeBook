using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeBook.Data;
using CafeBook.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Repositories
{
    public class BookTypeRepository:IBookTypeRepository
    {
        readonly CafeBookContext _context;
        public BookTypeRepository(CafeBookContext context)
        {
            _context = context;
        }

        public void Add(BookType bookType)
        {
            _context.Add(bookType);
        }

        public void Update(BookType bookType)
        {
            _context.Update(bookType);
        }

        public void Delete(BookType bookType)
        {
            _context.Remove(bookType);
        }

        public bool BookTypeExist(int id)
        {
            return _context.BookType.Any(m => m.Id == id);
        }

        public Task<List<BookType>> GetAll()
        {
            return _context.BookType.ToListAsync();
        }

        public Task<BookType> GetDetail(int? id)
        {
            return _context.BookType.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
