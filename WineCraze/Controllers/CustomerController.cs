using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Models.Customer;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Controllers
{
    [Authorize]
    public class CustomerController : BaseController
    {
        public IActionResult Index()
        {
            var customers = new List<CustomerViewModel>
            {
                new CustomerViewModel { Id = 1, Name = "John Doe", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "555-1234" },
                new CustomerViewModel { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Address = "456 Elm St", PhoneNumber = "555-5678" }
            };

            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = new CustomerViewModel { Id = id, Name = "John Doe", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "555-1234" };

            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerViewModel model)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = new CustomerViewModel { Id = id, Name = "John Doe", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "555-1234" };

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel model)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var customer = new CustomerViewModel { Id = id, Name = "John Doe", Email = "john@example.com", Address = "123 Main St", PhoneNumber = "555-1234" };

            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
      

// Summary - Manages customers, allowing for adding new customers, editing customer details,
// and viewing customer information.
