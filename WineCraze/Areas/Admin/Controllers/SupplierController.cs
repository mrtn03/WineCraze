using Microsoft.AspNetCore.Mvc;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Supplier;

namespace WineCraze.Areas.Admin.Controllers
{
    public class SupplierController : AdminBaseController
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _supplierService.GetAllSuppliers();
            return View(suppliers);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(id);
                return View(supplier);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(id);
                return View(supplier);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _supplierService.UpdateSupplier(viewModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var supplier = _supplierService.GetSupplierById(id);
                return View(supplier);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _supplierService.DeleteSupplier(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
