using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;
using CafeBook.Repositories;

namespace CafeBook.Services
{
    public class BookTypeService
    {
        private readonly IBookTypeRepository _repo;
        public BookTypeService(IBookTypeRepository repo)
        {
            _repo = repo;
        }

        // GET: Roles
        public async Task<List<BookType>> GetBookTypes()
        {
            return await _repo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<BookType> DetailsBookType(int? id)
        {
            return await _repo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        // For last method
        public bool BookTypeExis(int id)
        {
            return _repo.BookTypeExist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(BookType bookType)
        {
            _repo.Add(bookType);
            await _repo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Edit/5
        public async Task Update(BookType bookType)
        {
            _repo.Update(bookType);
            await _repo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        // POST: Roles/Delete/5
        public async Task Delete(BookType bookType)
        {
            _repo.Delete(bookType);
            await _repo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }
    }
}
