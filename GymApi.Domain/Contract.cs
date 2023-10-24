using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GymApi.Domain;

public class Contract
{
	private List<string> _validationErrors;
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ContractId { get; set; }
    public Guid UserId { get; set; }
    private DateTime _startDate;
    public DateTime StartDate { get; set; }

    private DateTime _endDate;
    public DateTime EndDate { get; set; }
    private string _userPlan;
    public string UserPlan { get; set; }

    private ICollection<string> _terms;
    public ICollection<string> Terms { get; set; }

    private void ValidateStartDate()
    {
	    if (StartDate < DateTime.Today)
		    _validationErrors.Add("StartDate cannot be in the past.");
    }

    private void ValidateEndDate()
    {
	    if (EndDate < StartDate)
		    _validationErrors.Add("EndDate cannot be before StartDate.");
    }

    private void ValidateUserPlan()
    {
	    if (string.IsNullOrWhiteSpace(UserPlan))
		    _validationErrors.Add("UserPlan is required.");
    }

    private void ValidateTerms()
    {
	    if (Terms == null || !Terms.Any())
		    _validationErrors.Add("Terms must have at least one item.");
    }

    public void Validate()
    {
	    ValidateStartDate();
	    ValidateEndDate();
	    ValidateUserPlan();
	    ValidateTerms();

	    if (_validationErrors.Any())
		    throw new ArgumentException(string.Join(", ", _validationErrors));

    }
}