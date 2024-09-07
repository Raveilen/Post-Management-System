using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PostManagementSystem.Data;
using PostManagementSystem.Models;
using PostManagementSystem.ViewModels;

namespace PostManagementSystem.Controllers
{
    [Authorize]
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
            var addresses = _context.Addresses.Include(a => a.City).ToList();
            ViewData["Address"] = new SelectList(addresses, "AddressID", "FullAddress");
            return View();
        }

        // POST: PostOffices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostOfficeViewModel postOfficeData)
        {
            if (ModelState.IsValid)
            {
                PostOffice postOffice = new();
                postOffice.packageSCapacity = postOfficeData.SCapacity;
                postOffice.packageMCapacity = postOfficeData.MCapacity;
                postOffice.packageLCapacity = postOfficeData.LCapacity;
                postOffice.AddressID = postOfficeData.AddressID;

                var address = _context.Addresses.FirstOrDefault(a => a.AddressID == postOfficeData.AddressID);
                if(address == null)
                {
                    return NotFound();
                }
                postOffice.Address = address;

                await _context.AddAsync(postOffice);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: PostOffices/SetupSourcePO
        [HttpGet]
        public async Task<IActionResult> SetupSourcePO()
        {
            var SenderID = TempData["SenderID"] as Guid?;
            var ReceiverID = TempData["ReceiverID"] as Guid?;
            var PackageTypeID = TempData["PackageTypeID"] as Guid?;

            TempData["SenderID"] = SenderID;
            TempData["ReceiverID"] = ReceiverID;
            TempData["PackageTypeID"] = PackageTypeID;

            var postManagementContext = _context.PostOffices.Include(p => p.Address).ThenInclude(a => a.City);
            return View(await postManagementContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult GetSenderPOID(Guid? id)
        {
            var SenderID = TempData["SenderID"] as Guid?;
            var ReceiverID = TempData["ReceiverID"] as Guid?;
            var PackageTypeID = TempData["PackageTypeID"] as Guid?;

            TempData["SenderID"] = SenderID;
            TempData["ReceiverID"] = ReceiverID;
            TempData["PackageTypeID"] = PackageTypeID;
            TempData["SenderOfficeID"] = id;

            return RedirectToAction("SetupDestinationPO", "PostOffices");
        }

        [HttpGet]
        public async Task<IActionResult> SetupDestinationPO()
        {
            var SenderID = TempData["SenderID"] as Guid?;
            var ReceiverID = TempData["ReceiverID"] as Guid?;
            var PackageTypeID = TempData["PackageTypeID"] as Guid?;
            var SenderOfficeID = TempData["SenderOfficeID"] as Guid?;

            TempData["SenderID"] = SenderID;
            TempData["ReceiverID"] = ReceiverID;
            TempData["PackageTypeID"] = PackageTypeID;
            TempData["SenderOfficeID"] = SenderOfficeID;

            var postManagementContext = _context.PostOffices.Include(p => p.Address).ThenInclude(a => a.City);
            return View(await postManagementContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetReceiverPOID(Guid? id)
        {
            var SenderID = TempData["SenderID"] as Guid?;
            var ReceiverID = TempData["ReceiverID"] as Guid?;
            var PackageTypeID = TempData["PackageTypeID"] as Guid?;
            var SenderOfficeID = TempData["SenderOfficeID"] as Guid?;

            if(SenderOfficeID == id) //sender and receiver are the same
            {
                return NotFound();
            }

            TempData["SenderID"] = SenderID;
            TempData["ReceiverID"] = ReceiverID;
            TempData["PackageTypeID"] = PackageTypeID;
            TempData["SenderOfficeID"] = SenderOfficeID;
            TempData["ReceiverOfficeID"] = id;

            return RedirectToAction("CreateDelivery", "Deliveries");
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

            var postOfficeData = new PostOfficeViewModel
            {
                PostOfficeID = postOffice.PostOfficeID,
                AddressID = postOffice.AddressID,
                SCapacity = postOffice.packageSCapacity,
                MCapacity = postOffice.packageMCapacity,
                LCapacity = postOffice.packageLCapacity
            };

            var fullAddresses = _context.Addresses.Include(a => a.City).ToList();
            ViewData["Address"] = new SelectList(fullAddresses, "AddressID", "FullAddress");
            return View(postOfficeData);
        }

        // POST: PostOffices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PostOfficeViewModel postOfficeData)
        {
            var postOffice = await _context.PostOffices.FirstOrDefaultAsync(p => p.PostOfficeID == postOfficeData.PostOfficeID);

            if(postOffice == null)
            {
                return NotFound();
            }

            if (id != postOffice.PostOfficeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                postOffice.packageSCapacity = postOfficeData.SCapacity;
                postOffice.packageMCapacity = postOfficeData.MCapacity;
                postOffice.packageLCapacity = postOfficeData.LCapacity;
                postOffice.AddressID = postOfficeData.AddressID;
                
                var address = _context.Addresses.FirstOrDefault(a => a.AddressID == postOfficeData.AddressID);
                if(address == null)
                {
                    return NotFound();
                }

                postOffice.Address = address;
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
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
