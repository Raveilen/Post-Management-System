using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Data;
using PostManagementSystem.Models;
using PostManagementSystem.ViewModels;

namespace PostManagementSystem.Controllers
{
    [Authorize]
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

            ViewData["City"] = new SelectList(cities, "Name", "Name");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddressViewModel addressData)
        {
            Address address = new Address();
            address.Street = addressData.Street;
            address.DwellingNumber = addressData.DwellingNumber;
            address.ApartmentNumber = addressData.ApartmentNumber;
            address.PostalCode = addressData.PostalCode;
            address.CityID = _context.Cities.FirstOrDefault(c => c.Name == addressData.City).CityID;
            address.City = _context.Cities.FirstOrDefault(c => c.Name == addressData.City);

            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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

            var addressData = new AddressViewModel
            {
                Street = address.Street,
                DwellingNumber = address.DwellingNumber,
                ApartmentNumber = address.ApartmentNumber,
                PostalCode = address.PostalCode,
                City = address.City.Name
            };

            var cities = await _context.Cities.ToListAsync();
            ViewData["City"] = new SelectList(cities, "Name", "Name", address.CityID);

            return View(addressData);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AddressViewModel addressData)
        {
            var address = await _context.Addresses.Include(a => a.City).FirstOrDefaultAsync(a => a.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            if(address.AddressID != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                address.Street = addressData.Street;
                address.DwellingNumber = addressData.DwellingNumber;
                address.ApartmentNumber = addressData.ApartmentNumber;
                address.PostalCode = addressData.PostalCode;

                address.City = _context.Cities.FirstOrDefault(c => c.Name == addressData.City);
                address.CityID = _context.Cities.FirstOrDefault(c => c.Name == addressData.City).CityID;

                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
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
