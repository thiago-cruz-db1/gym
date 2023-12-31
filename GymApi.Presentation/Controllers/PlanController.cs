﻿using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using GymApi.UseCases.Services.Plan;
using GymApi.UseCases.Services.PlanHandler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlanController : ControllerBase
    {
	    private readonly GetByIdPlanCommandHandler _getByIdPlan;
	    private readonly GetAllPlanCommandHandler _getAllPlan;
        private readonly IMediator _mediator;

        public PlanController(IMediator mediator, GetByIdPlanCommandHandler getByIdPlan, GetAllPlanCommandHandler getAllPlan)
        {
	        _mediator = mediator;
	        _getByIdPlan = getByIdPlan;
	        _getAllPlan = getAllPlan;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlan([FromBody] CreatePlanCommand planDto, CancellationToken cancellationToken)
        {
            try
            {
	            var response = await _mediator.Send(planDto);
	            return Ok(response);;
            }
            catch (Exception e)
            {
                throw new Exception("error on create plan", e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var plans = await _getAllPlan.HandleGetAll();
                return Ok(plans);
            }
            catch (Exception e)
            {
                throw new Exception("error on get plan", e);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanById(Guid id)
        {
            try
            {
                var plan = await _getByIdPlan.HandleGetById(id);
                if (plan == null!) return NotFound();
                return Ok(plan);
            }
            catch (Exception e)
            {
                throw new Exception("error on get plan", e);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanById([FromBody] UpdatePlanCommand updatePlanDto)
        {
            try
            {
	            var response = await _mediator.Send(updatePlanDto);
	            return Ok(response);
            }
            catch (Exception e)
            {
                throw new Exception("error on update plan", e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanById(DeletePlanCommand plan)
        {
            try
            {
	            var response = await _mediator.Send(plan.Id);
	            return Ok(response);
            }
            catch (Exception e)
            {
                throw new Exception("error on delete plan", e);
            }
        }
    }
}
