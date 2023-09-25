using GymApi.Domain;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ContractUserController : ControllerBase
{
    private readonly ContractGymService _contractGymService;

    public ContractUserController(ContractGymService contractGymService) =>
        _contractGymService = contractGymService;

    [HttpGet]
    public async Task<List<Contract>> Get() =>
        await _contractGymService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Contract>> Get(string id)
    {
        var contract = await _contractGymService.GetAsync(id);
        if (contract is null) return NotFound();
        return contract;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Contract newContract)
    {
        await _contractGymService.CreateAsync(newContract);
        return CreatedAtAction(nameof(Get), new { id = newContract.ContractId }, newContract);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Contract updatedContract)
    {
        var contract = await _contractGymService.GetAsync(id);
        if (contract is null) return NotFound();
        updatedContract.ContractId = contract.ContractId;
        await _contractGymService.UpdateAsync(id, updatedContract);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var contract = await _contractGymService.GetAsync(id);
        if (contract is null) return NotFound();
        await _contractGymService.RemoveAsync(id);
        return NoContent();
    }
}