namespace GymApi.Domain;

public class Exercise
{
	private List<string> _validationErrors;
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Machine { get; set; }
	public int Pause { get; set; }
	public int Set { get; set; }
	public int Repetition { get; set; }
	public string Technique { get; set; }

	public ICollection<ExerciseTraining> ExerciseTrainings { get; set; }

	private void ValidateMachine()
	{
		if (string.IsNullOrWhiteSpace(Machine))
			_validationErrors.Add("Machine is required.");
	}

	private void ValidatePause()
	{
		if (Pause < 0)
			_validationErrors.Add("Pause must be greater than or equal to 0.");
	}

	private void ValidateSet()
	{
		if (Set <= 0)
			_validationErrors.Add("Set must be greater than 0.");
	}

	private void ValidateRepetition()
	{
		if (Repetition <= 0)
			_validationErrors.Add("Repetition must be greater than 0.");
	}

	private void ValidateTechnique()
	{
		if (string.IsNullOrWhiteSpace(Technique))
			_validationErrors.Add("Technique is required.");
	}

	public void Validate()
	{
		_validationErrors = new List<string>();

		ValidateMachine();
		ValidatePause();
		ValidateSet();
		ValidateRepetition();
		ValidateTechnique();

		if (_validationErrors.Any())
			throw new ArgumentException(string.Join(", ", _validationErrors));
	}
}