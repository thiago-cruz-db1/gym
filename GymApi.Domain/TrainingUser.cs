﻿namespace GymApi.Domain;

public class TrainingUser
{
	private List<string> _validationErrors;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string TrainingObservations { get; set; }

    private string _userId;

    public string UserId { get; set; }
    public User User { get; set; }

    public Guid TrainingId { get; set; }
    public Training Training { get; set; }

    private void ValidateUserId()
    {
	    if (string.IsNullOrWhiteSpace(UserId))
		    _validationErrors.Add("Name is required.");
	    else if (UserId.Length > 100)
		    _validationErrors.Add("Name must not exceed 100 characters.");
    }

    public void Validate()
    {
	    ValidateUserId();

	    if (_validationErrors.Any())
		    throw new ArgumentException(string.Join(", ", _validationErrors));
    }
}