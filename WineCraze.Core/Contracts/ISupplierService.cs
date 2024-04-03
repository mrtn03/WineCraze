using WineCraze.Core.Models.Supplier;

namespace WineCraze.Core.Contracts
{
    public interface ISupplierService
    {
        IEnumerable<SupplierViewModel> GetAllSuppliers();
        SupplierViewModel GetSupplierById(int id);
        void CreateSupplier(SupplierViewModel viewModel);
        void UpdateSupplier(SupplierViewModel viewModel);
        void DeleteSupplier(int id);
    }
}
