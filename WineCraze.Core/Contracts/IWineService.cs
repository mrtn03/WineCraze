﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Contracts
{
    public interface IWineService
    {
        Task<IEnumerable<Wine>> GetAllWinesAsync();
        Task<Wine> GetWineByIdAsync(int id);
        Task<IEnumerable<Wine>> GetLastThreeWineAsync();
        Task AddAsync(Wine wine);
        Task UpdateAsync(Wine wine);
        Task DeleteAsync(int id);
    }
}
