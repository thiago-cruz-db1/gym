namespace GymApi.Domain;

public class Training
{
	private List<string> _validationErrors;
    public Guid Id { get; set; } = Guid.NewGuid();

    private string _name;
    public string Name { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(2);

    public ICollection<TrainingUser> UserTrainings { get; set; }
    public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }


    private void ValidateName()
    {
	    if (string.IsNullOrWhiteSpace(Name))
		    _validationErrors.Add("Name is required.");
	    else if (Name.Length > 100)
		    _validationErrors.Add("Name must not exceed 100 characters.");
    }

    public void Validate()
    {
	    ValidateName();

	    if (_validationErrors.Any())
		    throw new ArgumentException(string.Join(", ", _validationErrors));
    }
}