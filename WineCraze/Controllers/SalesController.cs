using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Sale;

namespace WineCraze.Controllers
{
    [Authorize]
    public class SalesController : BaseController
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return View(sales);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            // Populate dropdowns with related entities if needed
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleViewModel saleViewModel)
        {
            if (ModelState.IsValid)
            {
                await _saleService.CreateSaleAsync(saleViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(saleViewModel);
        }

        // Implement other action methods
    }
}

// Summary - Handles sales-related actions such as creating sales, viewing sales history, and generating sales reports.