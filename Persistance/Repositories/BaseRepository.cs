namespace Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext _context)
        {
            this._context = _context;
        }
    }
}