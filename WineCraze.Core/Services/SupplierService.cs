using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Supplier;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Common;

namespace WineCraze.Core.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository _supp;

        public SupplierService(IRepository _supp)
        {
            _supp = _supp;
        }

        public IEnumerable<SupplierViewModel> GetAllSuppliers()
        {
            throw new NotImplementedException();
        }

        public SupplierViewModel GetSupplierById(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateSupplier(SupplierViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier(SupplierViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier(int id)
        {
            throw new NotImplementedException();
        }
    }
}