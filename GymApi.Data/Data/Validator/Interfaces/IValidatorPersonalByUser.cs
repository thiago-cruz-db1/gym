using GymApi.Domain;

namespace GymApi.Data.Data.Validator.Interfaces;

public interface IValidatorPersonalByUser
{
	public bool IsPersonalOpenToNewClient(PersonalByUser personalByUser);
	public bool IsDuplicateClientOnSameTimeToPersonal(PersonalByUser personalByUser);
	public bool IsDuplicatePersonalOnSameTimeToClient(PersonalByUser personalByUser);
}