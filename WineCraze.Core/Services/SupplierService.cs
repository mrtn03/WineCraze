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
                    ContactPerson = s.ContactPerson,
                    Email = s.Email,
                    Phone = s.Phone,
                    Bulstat = s.Bulstat
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
                ContactPerson = supplier.ContactPerson,
                Bulstat = supplier.Bulstat,
                Email = supplier.Email,
                Phone = supplier.Phone
            };
        }

        public async void CreateSupplier(SupplierViewModel viewModel)
        {
            var supplier = new Supplier
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Id = viewModel.Id,
                ContactPerson = viewModel.ContactPerson,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Bulstat = viewModel.Bulstat
            };

            _supp.AddAsync(supplier);
            await _supp.SaveChangesAsync();
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
            supplier.Phone = viewModel.Phone;
            supplier.ContactPerson = viewModel.ContactPerson;
            supplier.Bulstat = viewModel.Bulstat;
            supplier.Email = viewModel.Email;

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