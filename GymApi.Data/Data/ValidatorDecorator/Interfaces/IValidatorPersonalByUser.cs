using GymApi.Domain;

namespace GymApi.Data.Data.ValidatorDecorator.Interfaces;

public interface IValidatorPersonalByUser
{
	public bool IsPeronalOpenToNewClient(PersonalByUser personalByUser);
	public bool IsDuplicateClientOnSameTimeToPersonal(PersonalByUser personalByUser);
	public bool IsDuplicatePersonalOnSameTimeToClient(PersonalByUser personalByUser);
}