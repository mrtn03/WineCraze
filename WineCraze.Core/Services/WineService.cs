using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Contracts;
using WineCraze.Core.Exceptions;
using WineCraze.Core.Models.Inventory;
using WineCraze.Core.Models.Supplier;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class WineService : IWineService
    {
        private readonly IRepository repository;

        public WineService(IRepository repositoryRepository)
        {
            repository = repositoryRepository;
        }

        public async Task<IEnumerable<WineViewModel>> GetAllWinesAsync()
        {
            var wineViewModels = await repository
                .All<Wine>()
                .Select(w => new WineViewModel()
                {
                    Id = w.Id,
                    Name = w.Name,
                    Country = w.Country,
                    Type = w.Type,
                    Price = w.Price,
                    CreatedOn = w.CreatedOn,
                    Region = w.Region,
                    ImageUrl = w.ImageUrl,
                    Quantity = w.Quantity

                })
                .ToListAsync();

            return wineViewModels;
        }

        public async Task<WineViewModel?> GetWineByIdAsync(int id)
        {
            var wine = await repository.GetByIdAsync<Wine>(id);

            if (wine is null)
            {
                return null;
            }

            var wineViewModel = new WineViewModel
            {
                Id = wine.Id,
                Name = wine.Name,
                Country = wine.Country,
                Type = wine.Type,
                Price = wine.Price,
                CreatedOn = wine.CreatedOn,
                Region = wine.Region,
                ImageUrl = wine.ImageUrl,
                Quantity = wine.Quantity,
            };

            return wineViewModel;
        }

        public async Task AddWineAsync(WineViewModel viewModel)
        {
            var wine = new Wine()
            {
                Name = viewModel.Name,
                Country = viewModel.Country,
                Type = viewModel.Type,
                Price = viewModel.Price,
                CreatedOn = DateTime.Now.ToString(),
                Region = viewModel.Region,
                ImageUrl = viewModel.ImageUrl,
                Quantity = viewModel.Quantity,
            };

            await repository.AddAsync(wine);
            await repository.SaveChangesAsync();
        }

        public async Task UpdateWineAsync(WineViewModel viewModel)
        {
            var wine = await repository.GetByIdAsync<Wine>(viewModel.Id);

            if (wine is null)
            {
                throw new WineUpdateException("Wine not found.");
               
            }

            try
            {
                wine.Name = viewModel.Name;
                wine.Country = viewModel.Country;
                wine.Type = viewModel.Type;
                wine.Price = viewModel.Price;
                wine.CreatedOn = viewModel.CreatedOn;
                wine.Region = viewModel.Region;
                wine.ImageUrl = viewModel.ImageUrl;
                wine.Quantity = viewModel.Quantity;

                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new WineUpdateException("Failed to update wine.", ex);
            }
        }
        public async Task DeleteWineAsync(int id)
        {
            var wine = await repository.GetByIdAsync<Wine>(id);
            if (wine is null)
            {
                throw new WineNotFoundException($"Wine with ID {id} not found.");
            }

            try
            {
                await repository.DeleteAsync<Wine>(wine.Id);
                await repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new WineDeletionException($"Error deleting wine with ID {id}.", ex);
            }
        }
        public async Task<IEnumerable<WineViewModel>> SearchWinesAsync(string searchTerm)
        {
            var wineViewModels = await repository
                .All<Wine>()
                .Where(w => w.Name.Contains(searchTerm) || w.Country.Contains(searchTerm) || w.Region.Contains(searchTerm))
                .Select(w => new WineViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    Country = w.Country,
                    Type = w.Type,
                    Price = w.Price,
                    CreatedOn = w.CreatedOn,
                    Region = w.Region,
                    ImageUrl = w.ImageUrl,
                    Quantity = w.Quantity
                })
                .ToListAsync();

            return wineViewModels;
        }
    }
}
