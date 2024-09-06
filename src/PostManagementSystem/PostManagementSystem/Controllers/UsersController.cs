using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PostManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using PostManagementSystem.ViewModels;
using System.Data;

namespace PostManagementSystem.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly PostManagementContext _context;

        public UsersController(PostManagementContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var roles = await _context.Roles.ToListAsync();
            ViewData["Role"] = new SelectList(roles, "Name", "Name");
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            ApplicationUser user = new ();
            user.Email = model.Email;
            user.NormalizedEmail = model.Email.ToUpper();
            user.EmailConfirmed = true;
            await _userManager.CreateAsync(user, model.Password);

            //roles
            var roles = await _context.Roles.ToListAsync();
            user.RoleID = roles.Where(r => r.Name == model.Role).FirstOrDefault().Id;
            user.Role = roles.Where(r => r.Name == model.Role).FirstOrDefault();
            
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Users/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userData = new UserViewModel
            {
                Email = user.Email,
                Role = user.Role.Name
            };

            var roles = await _context.Roles.ToListAsync();
            ViewData["Role"] = new SelectList(roles, "Name", "Name");

            return View(userData);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,UserViewModel userData)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                user.Email = userData.Email;

                var roles = await _context.Roles.ToListAsync();
                user.RoleID = roles.Where(r => r.Name == userData.Role).FirstOrDefault().Id;
                user.Role = roles.Where(r => r.Name == userData.Role).FirstOrDefault();

                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // GET: Users/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
