using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Data;
using PostManagementSystem.Models;
using PostManagementSystem.ViewModels;

namespace PostManagementSystem.Controllers
{
    [Authorize]
    public class PackageTypesController : Controller
    {
        private readonly PostManagementContext _context;

        public PackageTypesController(PostManagementContext context)
        {
            _context = context;
        }

        // GET: PackageTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PackageTypes.ToListAsync());
        }

        //GET: PackageTypes/ListPackaging
        public async Task<IActionResult> ListPackaging()
        {
            return View(await _context.PackageTypes.ToListAsync());
        }

        //get: PackageTypes/SelectPackaging
        [HttpGet]
        public async Task<IActionResult> SelectPackaging(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToAction("SetupSenderAndReceiver", "Customers", new { PackageTypeID = id});
        }

        // GET: PackageTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes
                .FirstOrDefaultAsync(m => m.PackageTypeID == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        //GET: PackageTypes/Image
        public async Task<IActionResult> GetImage(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }

            return File(packageType.Image, "image/jpg");
        }

        // GET: PackageTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PackageTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackageTypeViewModel packageTypeData)
        {
            if (ModelState.IsValid)
            {
                PackageType packageType = new();
                packageType.Name = packageTypeData.Name;
                packageType.MaxWeight = packageTypeData.MaxWeight;
                packageType.MaxDimensions = packageTypeData.MaxDimensions;
                packageType.IsFragile = packageTypeData.IsFragile;
                packageType.Cost = packageTypeData.Cost;

                switch (packageType.Name.ToUpper())
                {
                    case "SMALL":
                        packageType.Image = ImageConverter.ConvertImageToByteArray(ImageConverter.smallImagePath);
                        break;
                    case "MEDIUM":
                        packageType.Image = ImageConverter.ConvertImageToByteArray(ImageConverter.mediumImagePath);
                        break;
                    case "LARGE":
                        packageType.Image = ImageConverter.ConvertImageToByteArray(ImageConverter.largeImagePath);
                        break;
                    default:
                        packageType.Image = null;
                        break;
                }

                await _context.AddAsync(packageType);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PackageTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes.FindAsync(id);

            if (packageType == null)
            {
                return NotFound();
            }

            var packageTypeData = new PackageTypeViewModel
            {
                Name = packageType.Name,
                MaxWeight = packageType.MaxWeight,
                MaxDimensions = packageType.MaxDimensions,
                IsFragile = packageType.IsFragile,
                Cost = packageType.Cost
            };
            return View(packageTypeData);
        }

        // POST: PackageTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PackageTypeViewModel packageTypeData)
        {
            var packageType = await _context.PackageTypes.FindAsync(id);
            
            if (packageType == null) 
            {
                return NotFound();
            }

            if (id != packageType.PackageTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                packageType.Name = packageTypeData.Name;
                packageType.MaxWeight = packageTypeData.MaxWeight;
                packageType.MaxDimensions = packageTypeData.MaxDimensions;
                packageType.IsFragile = packageTypeData.IsFragile;
                packageType.Cost = packageTypeData.Cost;

                switch (packageType.Name.ToUpper())
                {
                    case "SMALL":
                        packageType.Image = ImageConverter.ConvertImageToByteArray(ImageConverter.smallImagePath);
                        break;
                    case "MEDIUM":
                        packageType.Image = ImageConverter.ConvertImageToByteArray(ImageConverter.mediumImagePath);
                        break;
                    case "LARGE":
                        packageType.Image = ImageConverter.ConvertImageToByteArray(ImageConverter.largeImagePath);
                        break;
                    default:
                        packageType.Image = null;
                        break;
                }

                await _context.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: PackageTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var packageType = await _context.PackageTypes
                .FirstOrDefaultAsync(m => m.PackageTypeID == id);
            if (packageType == null)
            {
                return NotFound();
            }

            return View(packageType);
        }

        // POST: PackageTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var packageType = await _context.PackageTypes.FindAsync(id);
            if (packageType != null)
            {
                _context.PackageTypes.Remove(packageType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageTypeExists(Guid id)
        {
            return _context.PackageTypes.Any(e => e.PackageTypeID == id);
        }
    }
}
