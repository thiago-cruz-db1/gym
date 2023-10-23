using GymApi.Domain.Enum;

namespace GymApi.Domain;

public class Plan
{
	private List<string> _validationErrors;
	public Guid Id { get; set; } = Guid.NewGuid();
	private double _amount;
	public double Amount
	{
		get => _amount;
		set
		{
			_amount = value;
			ValidateAmount();
		}
	}
	private string _category;
	public string Category
	{
		get => _category;
		set
		{
			_category = value;
			ValidateCategory();
		}
	}
	private int _totalMonths;
	public int TotalMonths
	{
		get => _totalMonths;
		set
		{
			_totalMonths = value;
			ValidateTotalMonths();
		}
	}
	private string _dayOfWeeks;
	public string DayOfWeeks
	{
		get => _dayOfWeeks;
		set
		{
			_dayOfWeeks = value;
			ValidateDayOfWeeks();
		}
	}
	public ICollection<User> Users { get; set; }
	public bool IsActive { get; set; } = true;

    private void ValidateAmount()
    {
	    if (Amount <= 0)
		    _validationErrors.Add("Amount must be greater than 0.");
    }

    private void ValidateCategory()
    {
	    if (string.IsNullOrWhiteSpace(Category))
		    _validationErrors.Add("Category is required.");
	    else if (Category.Length > 100)
		    _validationErrors.Add("Category must not exceed 100 characters.");
    }

    private void ValidateTotalMonths()
    {
	    if (TotalMonths <= 0)
		    _validationErrors.Add("TotalMonths must be greater than 0.");
    }

    private void ValidateDayOfWeeks()
    {
	    if (string.IsNullOrWhiteSpace(DayOfWeeks))
		    _validationErrors.Add("DayOfWeeks is required.");
	    else if (!BeValidDaysOfWeek(DayOfWeeks))
		    _validationErrors.Add("Invalid DaysOfWeek collection.");
    }

    private bool BeValidDaysOfWeek(string daysOfWeek)
    {
	    if (string.IsNullOrWhiteSpace(daysOfWeek)) return false;
	    var dayStrings = daysOfWeek.Split(',');
	    return dayStrings.All(dayString =>
	    {
		    var validDays = System.Enum.GetValues(typeof(DayOfWeekEnum)).Cast<DayOfWeekEnum>();
		    return dayStrings.All(day =>
			    validDays.Any(validDay => string.Equals(day.Trim(), validDay.ToString(), StringComparison.OrdinalIgnoreCase)));
	    });
    }

    public void Validate()
    {
	    _validationErrors = new List<string>();

	    ValidateAmount();
	    ValidateCategory();
	    ValidateTotalMonths();
	    ValidateDayOfWeeks();
    }
}

