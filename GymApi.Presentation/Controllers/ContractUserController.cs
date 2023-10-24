using GymApi.Domain;
using GymApi.UseCases.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractUserController : ControllerBase
{
    private readonly ContractGymService _contractGymService;

    public ContractUserController(ContractGymService contractGymService)
    {
        _contractGymService = contractGymService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateContractRequest newContract)
    {
        try
        {
            await _contractGymService.CreateAsync(newContract);
            return CreatedAtAction(nameof(Get), new { id = newContract.ContractId }, newContract);
        }
        catch (Exception e)
        {
            throw new Exception("error on create contract",e);
        }
    }

    [HttpGet]
    public async Task<ICollection<Contract>> Get()
    {
        try
        {
            return await _contractGymService.GetAsync();
        }
        catch (Exception e)
        {
            throw new Exception("error on get contract",e);
        }
    }


    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Contract>> Get(string id)
    {
        try
        {
            var contract = await _contractGymService.GetAsync(id);
            if (contract is null) return NotFound();
            return contract;
        }
        catch (Exception e)
        {
            throw new Exception("error on get contract",e);
        }
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, UpdateContractRequest updatedContract)
    {
        try
        {
            var contract = await _contractGymService.GetAsync(id);
            if (contract is null) return NotFound();
            updatedContract.ContractId = contract.ContractId!;
            await _contractGymService.UpdateAsync(id, updatedContract);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on update contract",e);
        }
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var contract = await _contractGymService.GetAsync(id);
            if (contract is null) return NotFound();
            await _contractGymService.RemoveAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete contract",e);
        }
    }
}