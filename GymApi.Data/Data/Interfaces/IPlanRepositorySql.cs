using GymApi.Data.Data.BaseRepository;
using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface IPlanRepositorySql : IBaseRepositorySql<Guid, Plan>
{
	public bool IsValidName(string name);
}