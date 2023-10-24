using System.Reflection.Metadata.Ecma335;
using GymApi.Domain.Enum;

namespace GymApi.Domain;

public class PersonalTrainer
{
	private List<string> _validationErrors;
    public Guid Id { get; set; } = Guid.NewGuid();
    private string _name;

    public string Name { get; set; }

    private int _age;

    public int Age { get; set; }

    public HoursDayPersonal MaxMinutesPerDay { get; set; } = HoursDayPersonal.EightHours;
    public ICollection<PersonalByUser> PersonalByUsers { get; set; }


    private void ValidateName()
    {
	    if (string.IsNullOrWhiteSpace(Name))
		    _validationErrors.Add("Name is required.");
	    else if (Name.Length > 100)
		    _validationErrors.Add("Name must not exceed 100 characters.");
    }

    private void ValidateAge()
    {
		if (Age < 18)
		    _validationErrors.Add("Age have to be gretter than 18.");
    }

    public void Validate()
    {
	    _validationErrors = new List<string>();

	    ValidateName();
	    ValidateAge();

	    if (_validationErrors.Any())
		    throw new ArgumentException(string.Join(", ", _validationErrors));
    }
}