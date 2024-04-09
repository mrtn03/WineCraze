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
            try
            {
                var wines = await _wineService.GetAllWinesAsync();
                return View(wines);
            }
            catch (Exception e)
            {
                // logger for exception
                return NotFound();
            }
        }

        // GET: Wine/Details/5
        public async Task<IActionResult> Details(int id)
        {

            try
            {
                var wine = await _wineService.GetWineByIdAsync(id);

                if (wine is null)
                {
                    return NotFound();
                }
                return View(wine);
            }
            catch (Exception e)
            {
                // logger for exception
                return NotFound();
            }
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
            if (ModelState.IsValid is false)
            {
                return View(viewModel);
            }

            try
            {
                await _wineService.AddWineAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                // logger for exception
                return View(viewModel);
            }
        }

        // GET: Wine/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var wine = await _wineService.GetWineByIdAsync(id);

                if (wine is null)
                {
                    return NotFound();
                }

                return View(wine);
            }
            catch (Exception e)
            {
                // logger for exception
                return NotFound();
            }
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

            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            try
            {
                await _wineService.UpdateWineAsync(viewModel);
            }
            catch (ArgumentException)
            {
                // logger for exception
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Wine/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var wine = await _wineService.GetWineByIdAsync(id);

                if (wine is null)
                {
                    return NotFound();
                }

                return View(wine);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: Wine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _wineService.DeleteWineAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                // logger for exception
                return NotFound();
            }
        }
    }
}