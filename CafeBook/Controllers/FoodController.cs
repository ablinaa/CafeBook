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
    public class FoodController : Controller
    {
        private readonly FoodService _service;

        public FoodController(FoodService service)
        {
            _service = service;
        }

        // GET: Food
        public async Task<IActionResult> Index()
        {
            var foods = await _service.GetFoods();
            return View(foods);
        }

        // GET: Food/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _service.DetailsFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Food/Create
        public IActionResult Create()
        {
            ViewData["FoodTypeId"] = new SelectList(_service.getFoodType(), "Id", "Id");
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FoodName,FoodDescription,Volume,Price,ImgUrl,FoodTypeId")] Food food)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAndSave(food);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodTypeId"] = new SelectList(_service.getFoodType(), "Id", "Id", food.FoodTypeId);
            return View(food);
        }

        // GET: Food/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _service.DetailsFood(id);
            if (food == null)
            {
                return NotFound();
            }
            ViewData["FoodTypeId"] = new SelectList(_service.getFoodType(), "Id", "Id", food.FoodTypeId);
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FoodName,FoodDescription,Volume,Price,ImgUrl,FoodTypeId")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Update(food);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.Id))
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
            ViewData["FoodTypeId"] = new SelectList(_service.getFoodType(), "Id", "Id", food.FoodTypeId);
            return View(food);
        }

        // GET: Food/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _service.DetailsFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _service.DetailsFood(id);
            await _service.Delete(book);
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            return _service.FoodExis(id);
        }
    }
}
