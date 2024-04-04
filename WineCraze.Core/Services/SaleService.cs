using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Sale;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class SaleService : ISaleService
    {
        private readonly IRepository sale;

        public SaleService(IRepository _repository)
        {
            sale = _repository;
        }

        public Task CreateSaleAsync(SaleViewModel saleViewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSaleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SaleViewModel>> GetAllSalesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SaleViewModel> GetSaleByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSaleAsync(SaleViewModel saleViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
