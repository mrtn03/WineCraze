using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Supplier;

namespace WineCraze.Controllers
{
    [Authorize]
    public class SupplierController : BaseController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: Supplier
        public IActionResult Index()
        {
            var suppliers = _supplierService.GetAllSuppliers();
            return View(suppliers);
        }

        // GET: Supplier/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(id);
                return View(supplier);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _supplierService.CreateSupplier(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Supplier/Edit/5
        public IActionResult Edit(int id)
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(id);
                return View(supplier);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SupplierViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _supplierService.UpdateSupplier(viewModel);
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Supplier/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(id);
                return View(supplier);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _supplierService.DeleteSupplier(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}

// Summary - Manages suppliers, including adding new suppliers,
// updating supplier details, and viewing supplier information.