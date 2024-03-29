﻿using System;
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

        public void Update(Book book)
        {
            _context.Update(book);
        }

        public void Delete(Book book)
        {
            _context.Remove(book);
        }

        public bool Exist(int id)
        {
            return _context.Book.Any(m => m.Id == id);
        }

        public Task<List<Book>> GetAll()
        {
            return _context.Book.ToListAsync();
        }

        public Task<Book> GetDetail(int? id)
        {
            return _context.Book.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<BookType> GetBookType()
        {
            return _context.BookType;
        }
    }
}
