using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeBook.Data;
using CafeBook.Models;

namespace CafeBook.Controllers
{
    public class RentScheduleController : Controller
    {
        private readonly CafeBookContext _context;

        public RentScheduleController(CafeBookContext context)
        {
            _context = context;
        }

        // GET: RentSchedule
        public async Task<IActionResult> Index()
        {
            var cafeBookContext = _context.RentSchedule.Include(r => r.Book).Include(r => r.User);
            return View(await cafeBookContext.ToListAsync());
        }

        // GET: RentSchedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentSchedule = await _context.RentSchedule
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentSchedule == null)
            {
                return NotFound();
            }

            return View(rentSchedule);
        }

        // GET: RentSchedule/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: RentSchedule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfRent,DateOfReturn,UserId,BookId")] RentSchedule rentSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", rentSchedule.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rentSchedule.UserId);
            return View(rentSchedule);
        }

        // GET: RentSchedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentSchedule = await _context.RentSchedule.FindAsync(id);
            if (rentSchedule == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", rentSchedule.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rentSchedule.UserId);
            return View(rentSchedule);
        }

        // POST: RentSchedule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfRent,DateOfReturn,UserId,BookId")] RentSchedule rentSchedule)
        {
            if (id != rentSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentScheduleExists(rentSchedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Book, "Id", "Id", rentSchedule.BookId);
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", rentSchedule.UserId);
            return View(rentSchedule);
        }

        // GET: RentSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentSchedule = await _context.RentSchedule
                .Include(r => r.Book)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentSchedule == null)
            {
                return NotFound();
            }

            return View(rentSchedule);
        }

        // POST: RentSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rentSchedule = await _context.RentSchedule.FindAsync(id);
            _context.RentSchedule.Remove(rentSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentScheduleExists(int id)
        {
            return _context.RentSchedule.Any(e => e.Id == id);
        }
    }
}
