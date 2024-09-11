using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Data;
using SQLitePCL;

namespace PostManagementSystem.Controllers
{
    public class GraphController : Controller
    {
        private readonly PostManagementContext _context;

        public GraphController(PostManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult PackageStatusStatistics(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var uniqueEmailUsers = _context.Deliveries.GroupBy(d=>d.UserEmail).Select(grp => grp.First()).ToList();
            var uniqueEmails = uniqueEmailUsers.Select(u => u.UserEmail).ToList();
            ViewData["Users"] = new SelectList(uniqueEmails);

            return View();
        }


        [HttpGet]
        // GET: /Graph/GetGraphData?filterId=1

        public JsonResult GetGraphData(string searchString)
        {
            List<string> labels;
            List<int> values;

            if (searchString == null)
            {
                var uniqueLabels = _context.Deliveries
                    .Include(d => d.Status)
                    .GroupBy(d => d.StatusID)
                    .Select(grp => grp.First()).ToList();
                labels = uniqueLabels
                    .Select(s => s.Status.Name)
                    .ToList();
                values = _context.Deliveries
                    .GroupBy(d => d.StatusID)
                    .Select(g => g.Count())
                    .ToList();
            }
            else
            {
                var uniqueLabels = _context.Deliveries
                    .Include(d => d.Status)
                    .Where(x => x.UserEmail == searchString)
                    .GroupBy(d => d.StatusID)
                    .Select(grp => grp.First()).ToList();
                labels = uniqueLabels
                    .Select(d => d.Status.Name)
                    .ToList();
                values = _context.Deliveries
                    .Where(x => x.UserEmail == searchString)
                    .GroupBy(d => d.StatusID)
                    .Select(g => g.Count())
                    .ToList();
            }

            return Json(new { labels, values });
        }

    }
}
