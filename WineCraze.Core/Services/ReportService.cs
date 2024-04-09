using Microsoft.EntityFrameworkCore;
using WineCraze.Core.Contracts;
using WineCraze.Core.Models.Report;
using WineCraze.Infrastructure.Data.Common;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Core.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository _report;

        public ReportService(IRepository _repository)
        {
            _report = _repository;
        }

        public async Task<IEnumerable<ReportViewModel>> GetAllReportsAsync()
        {
            var reports = await _report
                .All<Report>()
                .Select(r => new ReportViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    DateCreated = r.DateCreated,
                })
                .ToListAsync();

            return reports;
        }

        public async Task<ReportViewModel?> GetReportByIdAsync(int id)
        {
            var report = await _report.GetByIdAsync<Report>(id);

            if (report == null)
                return null;

            return new ReportViewModel
            {
                Id = report.Id,
                Title = report.Title,
                Description = report.Description,
                DateCreated = report.DateCreated,
            };
        }

        public async Task CreateReportAsync(ReportViewModel reportViewModel)
        {
            var report = new Report
            {
                Title = reportViewModel.Title,
                Description = reportViewModel.Description,
                DateCreated = string.Empty,
                
            };

            await _report.AddAsync(report);
            await _report.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(ReportViewModel reportViewModel)
        {
            var report = await _report.GetByIdAsync<Report>(reportViewModel.Id);

            if (report == null)
                throw new ArgumentException("Report not found");

            report.Title = reportViewModel.Title;
            report.Description = reportViewModel.Description;
            report.DateCreated = reportViewModel.DateCreated;

            await _report.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(int id)
        {
            await _report.DeleteAsync<Report>(id);
            await _report.SaveChangesAsync();
        }
    }
}