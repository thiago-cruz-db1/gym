using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class ProductsRepository : BaseRepositoryAbstract<Guid, Product>, IProductsRepository
{
    public ProductsRepository(GymDbContext context) : base(context)
    {
    }
}