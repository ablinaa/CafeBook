﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepo;
        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        // GET: Roles
        public async Task<List<Book>> GetBook()
        {
            return await _bookRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Book> DetailsBook(int? id)
        {
            return await _bookRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool BookExis(int id)
        {
            return _bookRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Book book)
        {
            _bookRepo.Add(book);
            await _bookRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(Book book)
        {
            _bookRepo.Update(book);
            await _bookRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Book book)
        {
            _bookRepo.Delete(book);
            await _bookRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }

        public DbSet<BookType> getBookType()
        {
            return _bookRepo.GetBookType();
        }
    }
}
