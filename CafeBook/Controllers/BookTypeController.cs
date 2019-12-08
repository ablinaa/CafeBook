using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeBook.Data;
using CafeBook.Models;
using CafeBook.Services;

namespace CafeBook.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly BookTypeService _service;

        public BookTypeController(BookTypeService service)
        {
            _service = service;
        }

        // GET: BookType
        public async Task<IActionResult> Index()
        {
            var bookType = await _service.GetBookTypes();
            return View(bookType);
        }

        // GET: BookType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookType = await _service.DetailsBookType(id);
            if (bookType == null)
            {
                return NotFound();
            }

            return View(bookType);
        }

        // GET: BookType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] BookType bookType)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAndSave(bookType);
                return RedirectToAction(nameof(Index));
            }
            return View(bookType);
        }

        // GET: BookType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookType = await _service.DetailsBookType(id);
            if (bookType == null)
            {
                return NotFound();
            }
            return View(bookType);
        }

        // POST: BookType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] BookType bookType)
        {
            if (id != bookType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(bookType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookTypeExists(bookType.Id))
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
            return View(bookType);
        }

        // GET: BookType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookType = await _service.DetailsBookType(id);
            if (bookType == null)
            {
                return NotFound();
            }

            return View(bookType);
        }

        // POST: BookType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookType = await _service.DetailsBookType(id);
            await _service.Delete(bookType);
            return RedirectToAction(nameof(Index));
        }

        private bool BookTypeExists(int id)
        {
            return _service.BookTypeExis(id);
        }
    }
}
