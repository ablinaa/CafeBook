using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CafeBook.Data;
using CafeBook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.Controllers
{
    public class UserProfileController:Controller
    {
        private readonly CafeBookContext _context;
        private readonly UserManager<User> userManager;
        private User userGlobe;

        public UserProfileController(CafeBookContext context,
                                UserManager<User> userManager)
        {
            _context = context;
            this.userManager = userManager;
       
        }

        public IActionResult Index(ClaimsPrincipal principal)
        {
            //var user = GetUserUserByEmail(email);
            //var id = user.Id;
            var id = userManager.GetUserId(principal);
            var profile = _context.Profile.FirstOrDefault(p => p.UserId==id);

            //userGlobe = userManager.GetUserAsync(principal);

            return View(profile);
        }

        public Task<User> GetUserUserByEmail(string email)
        {
            var user = userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<IActionResult> EditProfile(ClaimsPrincipal principal)
        {
            var id = userManager.GetUserId(principal);
            var profile = await _context.Profile.FirstOrDefaultAsync(p => p.UserId.Equals(id));

            ViewData["UserId"] = id;
            return View(profile);
        }

        public async Task<IActionResult> Create([Bind("Id,Name,Surname,PhoneNumber,Email,UserId")] Profile profile)
        {
            profile.User = userGlobe;
            
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(profile);
        }

    }
}
