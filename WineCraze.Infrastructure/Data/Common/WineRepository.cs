using WineCraze.Data;
using WineCraze.Infrastructure.Data.Models;

namespace WineCraze.Infrastructure.Data.Common
{
    public class WineRepository : IWineRepository
    {
        private readonly WineCrazeDbContext _context;

        public WineRepository(WineCrazeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Wine> GetAll()
        {
            return _context.Wines.ToList();
        }

        public Wine GetById(int id)
        {
            return _context.Wines.Find(id);
        }

        public void Add(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
        }

        public void Update(Wine wine)
        {
            _context.Wines.Update(wine);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var wine = _context.Wines.Find(id);
            _context.Wines.Remove(wine);
            _context.SaveChanges();
        }
    }
}
