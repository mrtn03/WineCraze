using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCraze.Core.Models.InventoryOrWine;
using WineCraze.Infrastructure.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WineCraze.Core.Contracts
{
    public interface IWineService
    {
        Task<IEnumerable<WineViewModel>> GetAllWinesAsync();
        Task<WineViewModel?> GetWineByIdAsync(int id);
        Task AddWineAsync(WineViewModel viewModel);
        Task UpdateWineAsync(WineViewModel viewModel);
        Task DeleteWineAsync(int id);
    }
}


// Summary - Provides methods for managing wines.