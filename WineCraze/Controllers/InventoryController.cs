using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Controllers
{
    [Authorize]
    public class InventoryController : BaseController
    {
        private readonly WineCrazeDbContext _context;

        public InventoryController(WineCrazeDbContext context)
        {
            _context = context;
        }

        // GET: Inventory
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var wines = await _context.Wines.ToListAsync();
            return View(wines);
        }

        // GET: Inventory/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Year,Price,Quantity")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wine);
        }

        // GET: Inventory/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wines.FindAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            return View(wine);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Year,Price,Quantity")] Wine wine)
        {
            if (id != wine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineExists(wine.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wine);
        }

        // GET: Inventory/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wines
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wine = await _context.Wines.FindAsync(id);
            _context.Wines.Remove(wine!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineExists(int id)
        {
            return _context.Wines.Any(e => e.Id == id);
        }
    }
}



// Summary - Manages wine inventory, including adding, editing, and deleting wines.
