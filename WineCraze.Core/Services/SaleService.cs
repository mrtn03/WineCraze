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
        private readonly IRepository _sales;

        public SaleService(IRepository repository)
        {
            _sales = repository;
        }

        public async Task<IEnumerable<SaleViewModel>> GetAllSalesAsync()
        {
            var sales = await _sales.All<Sale>()
                .Select(s => new SaleViewModel
                {
                    Id = s.Id,
                    Quantity = s.Quantity,
                    TotalPrice = s.TotalPrice,
                    CustomerId = s.CustomerId,
                    WineId = s.WineId
                })
                .ToListAsync();

            return sales;
        }

        public async Task<SaleViewModel> GetSaleByIdAsync(int id)
        {
            var sale = await _sales.GetByIdAsync<Sale>(id);

            if (sale == null)
                return null;

            var saleViewModel = new SaleViewModel
            {
                Id = sale.Id,
                Quantity = sale.Quantity,
                TotalPrice = sale.TotalPrice,
                CustomerId = sale.CustomerId,
                WineId = sale.WineId
            };

            return saleViewModel;
        }

        public async Task CreateSaleAsync(SaleViewModel saleViewModel)
        {
            var sale = new Sale
            {
                Quantity = saleViewModel.Quantity,
                TotalPrice = saleViewModel.TotalPrice,
                CustomerId = saleViewModel.CustomerId,
                WineId = saleViewModel.WineId
            };

            await _sales.AddAsync(sale);
            await _sales.SaveChangesAsync();
        }

        public async Task UpdateSaleAsync(SaleViewModel saleViewModel)
        {
            var sale = await _sales.GetByIdAsync<Sale>(saleViewModel.Id);

            if (sale == null)
                throw new ArgumentException("Sale not found.");

            sale.Quantity = saleViewModel.Quantity;
            sale.TotalPrice = saleViewModel.TotalPrice;
            sale.CustomerId = saleViewModel.CustomerId;
            sale.WineId = saleViewModel.WineId;

            await _sales.SaveChangesAsync();
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _sales.GetByIdAsync<Sale>(id);

            if (sale == null)
                throw new ArgumentException("Sale not found.");

            _sales.DeleteAsync<Sale>(sale.Id);
            await _sales.SaveChangesAsync();
        }
    }
}
