using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Responses;
using Domain;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository activityRepository;
        private readonly IUnitOfWork unitOfWork;

        public ActivityService(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.activityRepository = activityRepository;
        }
        public async Task<ActivityResponse> addActivityAsync(Activity activity)
        {
            try
            {
                await activityRepository.AddActivityAsync(activity);
                await unitOfWork.CompleteTask();
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred during create an activity: {e.Message}");
            }

            return new ActivityResponse(activity);
        }

        public async Task<ActivityResponse> deleteActivityAsync(Guid id)
        {
            var existingActivity = await activityRepository.FindActivityByIdAsync(id);
            if (existingActivity == null)
            {
                return new ActivityResponse("Activity not found! Wrong ID used");
            }

            try
            {
                activityRepository.RemoveActivity(existingActivity);
                await unitOfWork.CompleteTask();
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred during delete an activity: {e.Message}");
            }

            return new ActivityResponse(existingActivity);
        }

        public async Task<ActivityResponse> listActivityAsync(Guid id)
        {
            var existingActivity = await activityRepository.FindActivityByIdAsync(id);
            if (existingActivity == null)
            {
                return new ActivityResponse("Activity not found! Wrong ID used");
            }

            return new ActivityResponse(existingActivity);
        }

        public async Task<IEnumerable<Activity>> listAllActivitiesAsync()
        {
            return await activityRepository.getAllActivitiesAsync();
        }

        public async Task<ActivityResponse> updateActivityAsync(Guid id, Activity activity)
        {
            var existingActivity = await activityRepository.FindActivityByIdAsync(id);
            if (existingActivity == null)
            {
                return new ActivityResponse("Activity not found! Wrong ID used");
            }

            existingActivity.Category = activity.Category;
            existingActivity.City = activity.City;
            existingActivity.Date = activity.Date;
            existingActivity.Description = activity.Description;
            existingActivity.Title = activity.Title;
            existingActivity.Venue = activity.Venue;

            try
            {
                activityRepository.UpdateActivity(existingActivity);
                await unitOfWork.CompleteTask();
            }
            catch (Exception e)
            {
                return new ActivityResponse($"An error occurred during update an activity: {e.Message}");
            }

            return new ActivityResponse(existingActivity);
        }
    }
}