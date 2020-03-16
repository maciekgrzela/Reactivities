using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Resources;
using Application.Activities;
using Application.Extensions;
using AutoMapper;
using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IActivityService _activityService;
        public ActivitiesController(IMapper mapper, IActivityService _activityService)
        {
            this._activityService = _activityService;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> getListOfActivities()
        {
            var activities = await _activityService.listAllActivitiesAsync();
            var activitiesResource = _mapper.Map<IEnumerable<ActivityResource>>(activities);

            return Ok(activitiesResource);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getActivity(Guid id)
        {
            var result = await _activityService.listActivityAsync(id);

            if (!result.Status)
            {
                return BadRequest(result.Message);
            }

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Activity);

            return Ok(activityResource);
        }

        [HttpPost]
        public async Task<IActionResult> createActivity([FromBody] SaveActivityResource saveActivityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var activity = _mapper.Map<SaveActivityResource, Activity>(saveActivityResource);
            var result = await _activityService.addActivityAsync(activity);

            if (!result.Status)
            {
                return BadRequest(result.Message);
            }

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Activity);
            return Ok(activityResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateActivity(Guid Id, [FromBody] SaveActivityResource saveActivityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var activity = _mapper.Map<SaveActivityResource, Activity>(saveActivityResource);
            var result = await _activityService.updateActivityAsync(Id, activity);

            if (!result.Status)
            {
                return BadRequest(result.Message);
            }

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Activity);
            return Ok(activityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _activityService.deleteActivityAsync(id);
            if (!result.Status)
            {
                return BadRequest(result.Message);
            }

            var activityResource = _mapper.Map<Activity, ActivityResource>(result.Activity);

            return Ok(activityResource);
        }
    }
}