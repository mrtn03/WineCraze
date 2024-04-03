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
        private readonly IRepository _sale;

        public SaleService(IRepository _sale)
        {
            _sale = _sale;
        }

        public async Task<IEnumerable<SaleViewModel>> GetAllSalesAsync()
        {
            var sales = await _sale.Sales
                .Select(s => new SaleViewModel
                {
                    Id = s.Id,
                    CustomerId = s.CustomerId,
                    SupplierId = s.SupplierId,
                    WineId = s.WineId,
                    Quantity = s.Quantity,
                    TotalPrice = s.TotalPrice
                })
                .ToListAsync();

            return sales;
        }

        public async Task CreateSaleAsync(SaleViewModel saleViewModel)
        {
            var sale = new Sale
            {
                CustomerId = saleViewModel.CustomerId,
                SupplierId = saleViewModel.SupplierId,
                WineId = saleViewModel.WineId,
                Quantity = saleViewModel.Quantity,
                TotalPrice = saleViewModel.TotalPrice
            };

            _sale.Sales.Add(sale);
            await _sale.SaveChangesAsync();
        }

        public async Task<SaleViewModel> GetSaleByIdAsync(int id)
        {
            var sale = await _sale.Sales
                .Where(s => s.Id == id)
                .Select(s => new SaleViewModel
                {
                    Id = s.Id,
                    CustomerId = s.CustomerId,
                    SupplierId = s.SupplierId,
                    WineId = s.WineId,
                    Quantity = s.Quantity,
                    TotalPrice = s.TotalPrice
                })
                .FirstOrDefaultAsync();

            return sale;
        }

        public async Task UpdateSaleAsync(SaleViewModel saleViewModel)
        {
            var sale = await _sale.Sales.FindAsync(saleViewModel.Id);
            if (sale == null)
            {
                throw new ArgumentException("Sale not found");
            }

            sale.CustomerId = saleViewModel.CustomerId;
            sale.SupplierId = saleViewModel.SupplierId;
            sale.WineId = saleViewModel.WineId;
            sale.Quantity = saleViewModel.Quantity;
            sale.TotalPrice = saleViewModel.TotalPrice;

            await _sale.SaveChangesAsync();
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _sale.Sales.FindAsync(id);
            if (sale == null)
            {
                throw new ArgumentException("Sale not found");
            }

            _sale.Sales.Remove(sale);
            await _sale.SaveChangesAsync();
        }
    }
}
