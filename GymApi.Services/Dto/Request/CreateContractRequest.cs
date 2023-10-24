using GymApi.Domain;

namespace GymApi.UseCases.Dto.Request;

public class CreateContractRequest
{
    public string ContractId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserPlan { get; set; }
    public int Terms { get; set; }
}