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

        public async Task<IEnumerable<SaleViewModel>> GetAllSalesAsync()
        {
            var sales = await sale.Sales
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

            sale.Sales.Add(sale);
            await sale.SaveChangesAsync();
        }

        public async Task<SaleViewModel> GetSaleByIdAsync(int id)
        {
            var sale = await sale.Sales
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
            var sale = await sale.Sales.FindAsync(saleViewModel.Id);
            if (sale == null)
            {
                throw new ArgumentException("Sale not found");
            }

            sale.CustomerId = saleViewModel.CustomerId;
            sale.SupplierId = saleViewModel.SupplierId;
            sale.WineId = saleViewModel.WineId;
            sale.Quantity = saleViewModel.Quantity;
            sale.TotalPrice = saleViewModel.TotalPrice;

            await sale.SaveChangesAsync();
        }

        public async Task DeleteSaleAsync(int id)
        {
            var sale = await _sale.Sales.FindAsync(id);
            if (sale == null)
            {
                throw new ArgumentException("Sale not found");
            }

            sale.Sales.Remove(sale);
            await sale.SaveChangesAsync();
        }
    }
}
