using GymApi.Data.Data.BaseRepository;
using GymApi.Data.Data.Interfaces;
using GymApi.Data.Data.MySql;
using GymApi.Domain;

namespace GymApi.Data.Data.PlanRepository;

public class ProductsRepositorySql : EntityFrameworkRepositorySqlAbstract<Guid, Product>, IProductsRepositorySql
{
    public ProductsRepositorySql(GymDbContext context) : base(context)
    {
    }
}