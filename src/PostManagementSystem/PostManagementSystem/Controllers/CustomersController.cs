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
    
    public class CustomersController : Controller
    {
        private readonly PostManagementContext _context;

        public CustomersController(PostManagementContext context)
        {
            _context = context;
        }

        // GET: Customers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.OrderBy(c => c.Surname).AsNoTracking().ToListAsync());
        }

        // GET: Customers/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }


        [Authorize(Roles = "Admin")]
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Surname,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ID = Guid.NewGuid();
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> SetupSenderAndReceiver(Guid packageTypeID)
        {
            ViewData["PackageTypeID"] = packageTypeID; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetupSenderAndReceiver(SenderAndReceiverViewModel srvm)
        {
            var customers = _context.Customers.ToList();

            var sender = customers
                .Where(c => (c.Name == srvm.SenderName))
                .Where(c => (c.Surname == srvm.SenderSurname))
                .Where(c => (c.Phone == srvm.SenderPhone))
                .FirstOrDefault();

            if (sender == null)
            {
                sender = new Customer
                {
                    ID = Guid.NewGuid(),
                    Name = srvm.SenderName,
                    Surname = srvm.SenderSurname,
                    Phone = srvm.SenderPhone
                };
                
                await _context.Customers.AddAsync(sender);
                await _context.SaveChangesAsync();
            }

            var receiver = customers
                .Where(c => (c.Name == srvm.ReceiverName))
                .Where(c => (c.Surname == srvm.ReceiverSurname))
                .Where(c => (c.Phone == srvm.ReceiverPhone))
                .FirstOrDefault();

            if (receiver == null)
            {
                receiver = new Customer
                {
                    ID = Guid.NewGuid(),
                    Name = srvm.ReceiverName,
                    Surname = srvm.ReceiverSurname,
                    Phone = srvm.ReceiverPhone
                };

                await _context.Customers.AddAsync(receiver);
                await _context.SaveChangesAsync();
            }

            if(sender.ID == receiver.ID) //sender and receiver are the same
            {
                return NotFound();
            }

            TempData["SenderID"] = sender.ID;
            TempData["ReceiverID"] = receiver.ID;
            TempData["PackageTypeID"] = srvm.PackageTypeID;

            return RedirectToAction("SetupSourcePO", "PostOffices");
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,Surname,Phone")] Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.ID))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(Guid id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
