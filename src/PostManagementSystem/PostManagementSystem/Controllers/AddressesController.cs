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
    public class AddressesController : Controller
    {
        private readonly PostManagementContext _context;

        public AddressesController(PostManagementContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index()
        {
            var postManagementContext = _context.Addresses.Include(a => a.City);
            return View(await postManagementContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            var cities = _context.Cities.ToList();

            ViewData["CityName"] = new SelectList(cities, "CityID", "Name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Address address)
        {
            if (ModelState.IsValid)
            {
                address.AddressID = Guid.NewGuid();
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var cities = await _context.Cities.ToListAsync();

            ViewData["CityName"] = new SelectList(cities, "CityID", "Name", address.CityID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.Include(a => a.City).FirstOrDefaultAsync(a => a.AddressID == id);

            if (address == null)
            {
                return NotFound();
            }

            var cities = await _context.Cities.ToListAsync();

            ViewData["CityName"] = new SelectList(cities, "CityID", "Name", address.CityID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AddressID,Street,DwellingNumber,ApartmentNumber,PostalCode,CityID")] Address address)
        {
            if (id != address.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressID))
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
            ViewData["CityID"] = new SelectList(_context.Cities, "CityID", "CityID", address.CityID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.City)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(Guid id)
        {
            return _context.Addresses.Any(e => e.AddressID == id);
        }
    }
}
