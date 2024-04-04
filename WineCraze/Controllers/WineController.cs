using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.InventoryOrWine;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Controllers
{
    public class WineController : BaseController
    {
        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

        // GET: Wine
        public async Task<IActionResult> Index()
        {
            var wines = await _wineService.GetAllWinesAsync();
            return View(wines);
        }

        // GET: Wine/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var wine = await _wineService.GetWineByIdAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            return View(wine);
        }

        // GET: Wine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WineViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _wineService.AddWineAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Wine/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var wine = await _wineService.GetWineByIdAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            return View(wine);
        }

        // POST: Wine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WineViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _wineService.UpdateWineAsync(viewModel);
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Wine/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var wine = await _wineService.GetWineByIdAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            return View(wine);
        }

        // POST: Wine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _wineService.DeleteWineAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}