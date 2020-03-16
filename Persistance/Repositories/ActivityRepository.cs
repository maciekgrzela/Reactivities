using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class ActivityRepository : BaseRepository, IActivityRepository
    {
        public ActivityRepository(DataContext _context) : base(_context) { }

        public async Task AddActivityAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
        }

        public async Task<Activity> FindActivityByIdAsync(Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }

        public async Task<IEnumerable<Activity>> getAllActivitiesAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public void RemoveActivity(Activity activity)
        {
            _context.Activities.Remove(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            _context.Activities.Update(activity);
        }
    }
}