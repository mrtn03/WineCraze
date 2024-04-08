using Microsoft.EntityFrameworkCore;
using Nest;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.InventoryOrWine;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class WineService : IWineService
    {
        //        private readonly IRepository wines;

        //        public WineService(IRepository _wineRepository)
        //        {
        //            wines = _wineRepository;
        //        }

        //        //public async Task<IEnumerable<WineViewModel>> GetAllWinesAsync()
        //        //{
        //        //    var ResWines = await wines.All<Wine>().ToListAsync();
        //        //    var wineViewModels = wines.Select(wine => new WineViewModel
        //        //    {
        //        //        Id = wine.Id,
        //        //        Name = wine.Name,
        //        //        // Add other properties as needed
        //        //    });
        //        //    return wineViewModels;
        //        //}

        //        public async Task<WineViewModel> GetWineByIdAsync(int id)
        //        {
        //            var resWine = await wines.GetByIdAsync<Wine>(id);
        //            if (resWine != null)
        //            {
        //                var wineViewModel = new WineViewModel
        //                {
        //                    Id = resWine.Id,
        //                    Name = resWine.Name,
        //                };
        //                return wineViewModel;
        //            }
        //            return null; 
        //        }

        //        public async Task AddWineAsync(WineViewModel viewModel)
        //        {
        //            var wine = new Wine
        //            {
        //                Name = viewModel.Name,
        //            };
        //            await wines.AddAsync(wine);
        //            await wines.SaveChangesAsync();
        //        }

        //        public async Task UpdateWineAsync(WineViewModel viewModel)
        //        {
        //            //var wine = await wines.GetByIdAsync<Wine>(viewModel.Id);
        //            //if (wine != null)
        //            //{
        //            //    wine.Name = viewModel.Name;
        //            //    // Update other properties
        //            //    wines.Update(wine);
        //            //    await wines.SaveChangesAsync();
        //            //}
        //            else
        //            {
        //                throw new ArgumentException("Wine not found.");
        //            }
        //        }

        //        public async Task DeleteWineAsync(int id)
        //        {
        //            //var wine = await wines.GetByIdAsync<Wine>(id);
        //            //if (wine != null)
        //            //{
        //            //    wines.Delete(wine);
        //            //    await wines.SaveChangesAsync();
        //            //}
        //            else
        //            {
        //                throw new ArgumentException("Wine not found.");
        //            }
        //        }
        //    }
        //}
        public Task AddWineAsync(WineViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWineAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WineViewModel>> GetAllWinesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WineViewModel> GetWineByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWineAsync(WineViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}