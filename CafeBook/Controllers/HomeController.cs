using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeBook.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CafeBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookService _bookService;
        private readonly BookTypeService _bookTypeService;

        public HomeController(BookService bookService, BookTypeService bookTypeService)
        {
            _bookService = bookService;
            _bookTypeService = bookTypeService;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var bookTypes = await _bookTypeService.GetBookTypes();
            return View(bookTypes);
        }
    }
}
