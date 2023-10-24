using GymApi.Domain.Enum;

namespace GymApi.Domain;

public class Plan
{
	private List<string> _validationErrors = new();
	public Guid Id { get; set; } = Guid.NewGuid();
	private double _amount;
	public double Amount { get; set; }
	private string _category;
	public string Category  { get; set; }
	private int _totalMonths;
	public int TotalMonths { get; set; }
	private string _dayOfWeeks;
	public string DayOfWeeks { get; set; }
	public ICollection<User> Users { get; set; }
	public bool IsActive { get; set; } = true;

    private void ValidateAmount()
    {
	    if (Amount <= 0)
		    _validationErrors.Add("Amount must be greater than 0.");
    }

    private  void  ValidateCategory()
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
	    ValidateAmount();
	    ValidateCategory();
	    ValidateTotalMonths();
	    ValidateDayOfWeeks();

	    if (_validationErrors.Any())
		    throw new ArgumentException(string.Join(", ", _validationErrors));
    }
}