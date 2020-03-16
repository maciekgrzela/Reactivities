using System.Threading.Tasks;
using Domain.Repositories;

namespace Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext _context)
        {
            this._context = _context;
        }

        public async Task CompleteTask()
        {
            await _context.SaveChangesAsync();
        }
    }
}