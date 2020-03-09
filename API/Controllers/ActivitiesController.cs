using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Resources;
using Application.Activities;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ActivitiesController(IMediator mediator, IMapper mapper)
        {
            this._mapper = mapper;
            this._mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<ActivityResource>> List()
        {
            var activities = await _mediator.Send(new List.Query());
            var activitiesMapped = _mapper.Map<IEnumerable<ActivityResource>>(activities);

            return activitiesMapped;
        }


        [HttpGet("{id}")]
        public async Task<ActivityResource> Details(Guid id) {
            var singleActivity = await _mediator.Send(new Details.Query { Id = id });
            var activityMapped = _mapper.Map<ActivityResource>(singleActivity);

            return activityMapped;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid Id, Edit.Command command)
        {
            command.Id = Id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }
    }
}