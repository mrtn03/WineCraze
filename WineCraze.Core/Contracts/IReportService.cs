using WineCraze.Core.Models.Report;

namespace WineCraze.Core.Contracts
{
    public interface IReportService
    {
        Task<List<ReportViewModel>> GetAllReportsAsync();
        Task<ReportViewModel> GetReportByIdAsync(int id);
        Task CreateReportAsync(ReportViewModel reportViewModel);
        Task UpdateReportAsync(ReportViewModel reportViewModel);
        Task DeleteReportAsync(int id);
    }
}
