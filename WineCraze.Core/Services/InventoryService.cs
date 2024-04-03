using WineCraze.Core.Contracts;
using WineCraze.Core.Models.InventoryOrWine;
using WineCraze.Data;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly WineCrazeDbContext _context;

        public InventoryService(WineCrazeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WineViewModel> GetAllWines()
        {
            return _context.Wines.Select(w => new WineViewModel
            {
                Id = w.Id,
                Name = w.Name,
                Type = w.Type,
                Country = w.Country,
                Region = w.Region,
                CreatedOn = w.CreatedOn,
                Price = w.Price,
                Quantity = w.Quantity,
                ImageUrl = w.ImageUrl,
                SupplierId = w.SupplierId
            }).ToList();
        }

        public WineViewModel GetWineById(int id)
        {
            var wine = _context.Wines.Find(id);

            if (wine == null)
            {
                throw new InvalidOperationException($"Wine with ID {id} not found.");
            }

            return new WineViewModel
            {
                Id = wine.Id,
                Name = wine.Name,
                Type = wine.Type,
                Country = wine.Country,
                Region = wine.Region,
                CreatedOn = wine.CreatedOn,
                Price = wine.Price,
                Quantity = wine.Quantity,
                ImageUrl = wine.ImageUrl,
                SupplierId = wine.SupplierId
            };
        }

        public void CreateWine(WineViewModel viewModel)
        {
            var wine = new Wine
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                Country = viewModel.Country,
                Region = viewModel.Region,
                CreatedOn = viewModel.CreatedOn,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                ImageUrl = viewModel.ImageUrl,
                SupplierId = viewModel.SupplierId
            };

            _context.Wines.Add(wine);
            _context.SaveChanges();
        }

        public void UpdateWine(WineViewModel viewModel)
        {
            var wine = _context.Wines.Find(viewModel.Id);

            if (wine == null)
            {
                throw new InvalidOperationException($"Wine with ID {viewModel.Id} not found.");
            }

            wine.Name = viewModel.Name;
            wine.Type = viewModel.Type;
            wine.Country = viewModel.Country;
            wine.Region = viewModel.Region;
            wine.CreatedOn = viewModel.CreatedOn;
            wine.Price = viewModel.Price;
            wine.Quantity = viewModel.Quantity;
            wine.ImageUrl = viewModel.ImageUrl;
            wine.SupplierId = viewModel.SupplierId;

            _context.SaveChanges();
        }

        public void DeleteWine(int id)
        {
            var wine = _context.Wines.Find(id);

            if (wine == null)
            {
                throw new InvalidOperationException($"Wine with ID {id} not found.");
            }

            _context.Wines.Remove(wine);
            _context.SaveChanges();
        }
    }
}