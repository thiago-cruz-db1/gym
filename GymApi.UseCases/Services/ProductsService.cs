using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class ProductsService
{
    private readonly IMapper _mapper;
    public readonly IProductsRepositorySql _contextProducts;

    public ProductsService(IProductsRepositorySql contextProducts,IMapper mapper)
    {
        _contextProducts = contextProducts;
        _mapper = mapper;
    }
    public Product AddProduct(AddProductRequest productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _contextProducts.Save(product);
        return product;
    }

    public async Task<ICollection<Product>> GetProducts()
    {
        return await _contextProducts.FindAll();
    }

    public async Task<Product> GetProductById(Guid id)
    {
        return await _contextProducts.FindById(id);
    }

    public async void DeleteProductById(Guid id)
    {
        var plan = await _contextProducts.FindById(id);
        _contextProducts.Delete(plan);
    }
}