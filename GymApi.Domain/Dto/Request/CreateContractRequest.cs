namespace GymApi.Domain.Dto.Request;

public class CreateContractRequest
{
    public string ContractId { get; set; }
    public User UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UsedPlan { get; set; }
    public int Terms { get; set; }
}