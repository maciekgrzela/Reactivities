using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> getAllActivitiesAsync();
        Task AddActivityAsync(Activity activity);
        Task<Activity> FindActivityByIdAsync(Guid id);
        void UpdateActivity(Activity activity);
        void RemoveActivity(Activity activity);

    }
}