using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Customer;

namespace WineCraze.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        // GET: /Customer
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return View(customers);
        }

        // GET: /Customer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return View(customer);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // GET: /Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddCustomerAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Customer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return View(customer);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST: /Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _customerService.UpdateCustomerAsync(viewModel);
                }
                catch (InvalidOperationException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: /Customer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                return View(customer);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}


// Summary - Manages customers, allowing for adding new customers, editing customer details,
// and viewing customer information.
