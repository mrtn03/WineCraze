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
        private readonly IInventoryService _wineService;

        public WineController(IInventoryService wineService)
        {
            _wineService = wineService;
        }

        // GET: /Inventory
        public IActionResult Index()
        {
            var wines = _wineService.GetAllWines();
            return View(wines);
        }

        // GET: /Inventory/Create
        public IActionResult Create()
        {
            var viewModel = new WineViewModel();
            return View(viewModel);
        }

        // POST: /Inventory/Create
        [HttpPost]
        public IActionResult Create(WineViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _wineService.CreateWine(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: /Inventory/Edit/5
        public IActionResult Edit(int id)
        {
            var viewModel = _wineService.GetWineById(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: /Inventory/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, WineViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _wineService.UpdateWine(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: /Inventory/Delete/5
        public IActionResult Delete(int id)
        {
            var viewModel = _wineService.GetWineById(id);
            if (viewModel == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // POST: /Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _wineService.DeleteWine(id);
            return RedirectToAction("Index");
        }
    }
}