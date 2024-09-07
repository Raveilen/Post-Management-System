using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Data;
using PostManagementSystem.Models;
using PostManagementSystem.ViewModels;

namespace PostManagementSystem.Controllers
{
    [Authorize]
    public class DeliveriesController : Controller
    {
        private readonly PostManagementContext _context;

        public DeliveriesController(PostManagementContext context)
        {
            _context = context;
        }

        // GET: Deliveries
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["DateSortParm"] = String.IsNullOrEmpty(sortOrder) || sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var statusNames = _context.Statuses.Select(s => s.Name).ToList();
            ViewData["Names"] = new SelectList(statusNames);

            var postManagementContext = _context.Deliveries
                .Include(d => d.Status)
                .Include(d => d.ReceiverPostOffice)
                .ThenInclude(po => po.Address)
                .ThenInclude(a => a.City)
                .Include(d => d.SenderPostOffice)
                .ThenInclude(po => po.Address)
                .ThenInclude(a => a.City)
                .Include(d => d.Package)
                .ThenInclude(p => p.Type)
                .Select(d => d);

            if (!String.IsNullOrEmpty(searchString))
            {
                postManagementContext = postManagementContext.Where(s => s.Status.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Date":
                    postManagementContext = postManagementContext.OrderBy(s => s.ExpectedDeliveryDate);
                    break;
                case "date_desc":
                    postManagementContext = postManagementContext.OrderByDescending(s => s.ExpectedDeliveryDate);
                    break;
            }

            return View(await postManagementContext.AsNoTracking().ToListAsync());
        }

        // GET: Deliveries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(m => m.DeliveryID == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryID,CreatedDate,ExpectedDeliveryDate,StatusUpdateDate")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                delivery.DeliveryID = Guid.NewGuid();
                _context.Add(delivery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(delivery);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDelivery()
        {
            var SenderID = TempData["SenderID"] as Guid?;
            var ReceiverID = TempData["ReceiverID"] as Guid?;
            var PackageTypeID = TempData["PackageTypeID"] as Guid?;
            var SenderOfficeID = TempData["SenderOfficeID"] as Guid?;
            var ReceiverOfficeID = TempData["ReceiverOfficeID"] as Guid?;

            var Sender = _context.Customers.FirstOrDefault(c => c.ID == SenderID);
            var Receiver = _context.Customers.FirstOrDefault(c => c.ID == ReceiverID);
            var PackageType = _context.PackageTypes.FirstOrDefault(p => p.PackageTypeID == PackageTypeID);
            var SenderOffice = _context.PostOffices.Include(po => po.Address).FirstOrDefault(po => po.PostOfficeID == SenderOfficeID);
            var ReceiverOffice = _context.PostOffices.Include(po => po.Address).FirstOrDefault(po => po.PostOfficeID == ReceiverOfficeID);

            var CreateDate = DateTime.Now;
            var ExpectedDeliveryDate = CreateDate.AddDays(3);
            var StatusUpdateDate = CreateDate;

            var UserEmail = User.Identity.Name;

            var StatusID = _context.Statuses.FirstOrDefault(s => s.Name == "Ordered").StatusID;
            var Status = _context.Statuses.FirstOrDefault(s => s.StatusID == StatusID);


            var deliveryData = new CreateDeliveryViewModel
            {
                PackageTypeID = PackageTypeID,
                PackageType = PackageType,
                SenderID = SenderID,
                Sender = Sender,
                ReceiverID = ReceiverID,
                Receiver = Receiver,
                SenderOfficeID = SenderOfficeID,
                SenderOffice = SenderOffice,
                ReceiverOfficeID = ReceiverOfficeID,
                ReceiverOffice = ReceiverOffice,
                StatusID = StatusID,
                Status = Status,
                CreateDate = CreateDate,
                StatusUpdateDate = StatusUpdateDate,
                ExpectedDeliveryDate = ExpectedDeliveryDate,
                UserEmail = UserEmail
            };

            return View(deliveryData);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDelivery(CreateDeliveryViewModel deliveryData)
        {
            if (ModelState.IsValid)
            {
               
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Deliveries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeliveryID,CreatedDate,ExpectedDeliveryDate,StatusUpdateDate")] Delivery delivery)
        {
            if (id != delivery.DeliveryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delivery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryExists(delivery.DeliveryID))
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
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(m => m.DeliveryID == id);
            if (delivery == null)
            {
                return NotFound();
            }

            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);
            if (delivery != null)
            {
                _context.Deliveries.Remove(delivery);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryExists(Guid id)
        {
            return _context.Deliveries.Any(e => e.DeliveryID == id);
        }
    }
}
