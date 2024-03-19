using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCraze.Data;

namespace WineCraze.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly WineCrazeDbContext _context;

        public ReportController(WineCrazeDbContext context)
        {
            _context = context;
        }

        // GET: Report
        public IActionResult Index()
        {
            return View();
        }

        // GET: Report/Sales
        public async Task<IActionResult> Sales()
        {
            var sales = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Supplier)
                .Include(s => s.Wine)
                .ToListAsync();

            return View(sales);
        }

        // GET: Report/Inventory
        public async Task<IActionResult> Inventory()
        {
            var wines = await _context.Wines.ToListAsync();
            return View(wines);
        }

        // GET: Report/Profit
        public async Task<IActionResult> Profit()
        {
            var sales = await _context.Sales
                .Include(s => s.Wine)
                .ToListAsync();

            return View(sales);
        }
    }
}

// Summary - Generates various reports related to sales, inventory, and profit.