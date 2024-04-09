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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sales = await _saleService.GetAllSalesAsync();
            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaleViewModel saleViewModel)
        {
            if (id != saleViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _saleService.UpdateSaleAsync(saleViewModel);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(saleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _saleService.GetSaleByIdAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _saleService.DeleteSaleAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}

// Summary - Handles sales-related actions such as creating sales, viewing sales history, and generating sales reports.