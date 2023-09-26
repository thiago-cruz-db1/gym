using GymApi.Domain;

namespace GymApi.Data.Data.Interfaces;

public interface IProductsRepository : IBaseRepository<Guid, Product>
{
    
}