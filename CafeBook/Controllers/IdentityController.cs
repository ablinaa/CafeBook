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
    public class IdentityController : Controller
    {
        private readonly CafeBookContext _context;

        public IdentityController(CafeBookContext context)
        {
            _context = context;
        }

        // GET: Identity
        public async Task<IActionResult> Index()
        {
            var cafeBookContext = _context.Identity.Include(i => i.User);
            return View(await cafeBookContext.ToListAsync());
        }

        // GET: Identity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.Identity
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identity == null)
            {
                return NotFound();
            }

            return View(identity);
        }

        // GET: Identity/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Identity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IIN,CardNumber,IssueDate,ExpiryDate,IssuedBy,UserId")] Identity identity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(identity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", identity.UserId);
            return View(identity);
        }

        // GET: Identity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.Identity.FindAsync(id);
            if (identity == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", identity.UserId);
            return View(identity);
        }

        // POST: Identity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IIN,CardNumber,IssueDate,ExpiryDate,IssuedBy,UserId")] Identity identity)
        {
            if (id != identity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(identity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdentityExists(identity.Id))
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
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", identity.UserId);
            return View(identity);
        }

        // GET: Identity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var identity = await _context.Identity
                .Include(i => i.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (identity == null)
            {
                return NotFound();
            }

            return View(identity);
        }

        // POST: Identity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var identity = await _context.Identity.FindAsync(id);
            _context.Identity.Remove(identity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdentityExists(int id)
        {
            return _context.Identity.Any(e => e.Id == id);
        }
    }
}
