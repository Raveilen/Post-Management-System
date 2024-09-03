using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Data;
using PostManagementSystem.Models;

namespace PostManagementSystem.Controllers
{
    public class PostOfficesController : Controller
    {
        private readonly PostManagementContext _context;

        public PostOfficesController(PostManagementContext context)
        {
            _context = context;
        }

        // GET: PostOffices
        public async Task<IActionResult> Index()
        {
            var postManagementContext = _context.PostOffices.Include(p => p.Address).ThenInclude(a => a.City);
            return View(await postManagementContext.ToListAsync());
        }

        // GET: PostOffices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postOffice = await _context.PostOffices
                .Include(p => p.Address)
                .FirstOrDefaultAsync(m => m.PostOfficeID == id);
            if (postOffice == null)
            {
                return NotFound();
            }

            return View(postOffice);
        }

        // GET: PostOffices/Create
        public IActionResult Create()
        {
            var fullAddresses = _context.Addresses.Include(a => a.City).ToList();
            ViewData["Address"] = new SelectList(fullAddresses, "AddressID", "FullAddress");
            return View();
        }

        // POST: PostOffices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostOfficeID,packageSCapacity,packageMCapacity,packageLCapacity,AddressID")] PostOffice postOffice)
        {
            if (ModelState.IsValid)
            {
                postOffice.PostOfficeID = Guid.NewGuid();
                _context.Add(postOffice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var fullAddresses = _context.Addresses.Include(a => a.City).ToList();

            ViewData["Address"] = new SelectList(fullAddresses, "AddressID", "FullAddress", postOffice.AddressID);
            return View(postOffice);
        }

        // GET: PostOffices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postOffice = await _context.PostOffices.Include(p => p.Address).ThenInclude(a => a.City).FirstOrDefaultAsync(p => p.PostOfficeID == id);

            if (postOffice == null)
            {
                return NotFound();
            }

            var fullAddresses = _context.Addresses.Include(a => a.City).ToList();
            ViewData["Address"] = new SelectList(fullAddresses, "AddressID", "FullAddress", postOffice.AddressID);
            return View(postOffice);
        }

        // POST: PostOffices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PostOfficeID,packageSCapacity,packageMCapacity,packageLCapacity,AddressID")] PostOffice postOffice)
        {
            if (id != postOffice.PostOfficeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postOffice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostOfficeExists(postOffice.PostOfficeID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", postOffice.AddressID);
            return View(postOffice);
        }

        // GET: PostOffices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postOffice = await _context.PostOffices
                .Include(p => p.Address)
                .ThenInclude(a => a.City)
                .FirstOrDefaultAsync(m => m.PostOfficeID == id);
            if (postOffice == null)
            {
                return NotFound();
            }

            return View(postOffice);
        }

        // POST: PostOffices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postOffice = await _context.PostOffices.FindAsync(id);
            if (postOffice != null)
            {
                _context.PostOffices.Remove(postOffice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostOfficeExists(Guid id)
        {
            return _context.PostOffices.Any(e => e.PostOfficeID == id);
        }
    }
}
