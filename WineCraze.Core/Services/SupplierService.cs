using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Supplier;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository _supp;

        public SupplierService(IRepository repository)
        {
            _supp = repository;
        }

        public IEnumerable<SupplierViewModel> GetAllSuppliers()
        {
            return _supp.All<Supplier>()
                .Select(s => new SupplierViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Address = s.Address,
                })
                .ToList();
        }

        public SupplierViewModel GetSupplierById(int id)
        {
            var supplier = _supp.GetByIdAsync<Supplier>(id).Result;
            if (supplier == null)
            {
                throw new ArgumentException("Supplier not found.");
            }

            return new SupplierViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
            };
        }

        public void CreateSupplier(SupplierViewModel viewModel)
        {
            var supplier = new Supplier
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
            };

            _supp.AddAsync(supplier).Wait();
            _supp.SaveChangesAsync().Wait();
        }

        public void UpdateSupplier(SupplierViewModel viewModel)
        {
            var supplier = _supp.GetByIdAsync<Supplier>(viewModel.Id).Result;
            if (supplier == null)
            {
                throw new ArgumentException("Supplier not found.");
            }

            supplier.Name = viewModel.Name;
            supplier.Address = viewModel.Address;

            _supp.SaveChangesAsync().Wait();
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _supp.GetByIdAsync<Supplier>(id).Result;
            if (supplier == null)
            {
                throw new ArgumentException("Supplier not found.");
            }

            _supp.DeleteAsync<Supplier>(supplier.Id).Wait();
            _supp.SaveChangesAsync().Wait();
        }
    }
}