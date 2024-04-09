using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Inventory;
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
                        Quantity = w.Quantity,
                        SupplierId = w.SupplierId,

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
                    SupplierId = wine.SupplierId,
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
                    SupplierId = viewModel.SupplierId,
                };

                await repository.AddAsync(wine);
                await repository.SaveChangesAsync();
            }

            public async Task UpdateWineAsync(WineViewModel viewModel)
            {
                var wine = await repository.GetByIdAsync<Wine>(viewModel.Id);

                if (wine is null)
                {
                    throw new ArgumentException("Wine not found.");
                    // should be a custom exception and controller should handle it with try/catch
                }

                wine.Name = viewModel.Name;
                wine.Country = viewModel.Country;
                wine.Type = viewModel.Type;
                wine.Price = viewModel.Price;
                wine.CreatedOn = viewModel.CreatedOn;
                wine.Region = viewModel.Region;
                wine.ImageUrl = viewModel.ImageUrl;
                wine.Quantity = viewModel.Quantity;
                wine.SupplierId = viewModel.SupplierId;

                await repository.SaveChangesAsync();
            }

            public async Task DeleteWineAsync(int id)
            {
                var wine = await repository.GetByIdAsync<Wine>(id);

                if (wine is null)
                {
                    throw new ArgumentException("Wine not found.");
                    // should be a custom exception and controller should handle it with try/catch
                }

                await repository.DeleteAsync<Wine>(wine.Id);
                await repository.SaveChangesAsync();
            }
        }
     }