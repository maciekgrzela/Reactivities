using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Responses;

namespace Domain.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> listAllActivitiesAsync();
        Task<ActivityResponse> listActivityAsync(Guid id);
        Task<ActivityResponse> addActivityAsync(Activity activity);

        Task<ActivityResponse> updateActivityAsync(Guid id, Activity activity);

        Task<ActivityResponse> deleteActivityAsync(Guid id);

    }
}