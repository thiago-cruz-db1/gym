using AutoMapper;
using GymApi.Data.Data.Interfaces;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;

namespace GymApi.UseCases.Services;

public class ProductsService
{
    private readonly IMapper _mapper;
    private readonly IProductsRepositorySql _contextProducts;

    public ProductsService(IProductsRepositorySql contextProducts,IMapper mapper)
    {
        _contextProducts = contextProducts;
        _mapper = mapper;
    }
    public Product AddProduct(CreateProductRequest productDto)
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
    
    public async Task<Product> UpdateProductById(Guid id)
    {
        var product = await _contextProducts.FindById(id);
        await _contextProducts.Update(product);
        return product;
    }

    public async void DeleteProductById(Guid id)
    {
        var product = await _contextProducts.FindById(id);
        _contextProducts.Delete(product);
    }
}