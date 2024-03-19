using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly WineCrazeDbContext _context;

        public SalesController(WineCrazeDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var sales = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Supplier)
                .Include(s => s.Report)
                .Include(s => s.Wine)
                .ToListAsync();

            return View(sales);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            ViewBag.Suppliers = _context.Suppliers.ToList();
            ViewBag.Wines = _context.Wines.ToList();

            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CustomerId,SupplierId,ReportId,WineId,Quantity,TotalPrice")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(sale);
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Supplier)
                .Include(s => s.Report)
                .Include(s => s.Wine)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }
    }
}



// Summary - Handles sales-related actions such as creating sales,
// viewing sales history, and generating sales reports.