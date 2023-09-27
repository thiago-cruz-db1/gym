using GymApi.Domain.Dto.Request;
using GymApi.UseCases.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;
    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] AddProductRequest productDto)
    {
        try
        {
            var product = _productsService.AddProduct(productDto);
            return Ok(product);
        }
        catch (Exception e)
        {
            throw new Exception("error on create product",e);
        }
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        try
        {
            return Ok(_productsService.GetProducts());
        }
        catch (Exception e)
        {
            throw new Exception("error on get product",e);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(Guid id)
    {
        try
        {
            var product = _productsService.GetProductById(id);
            return Ok(product);
        }
        catch (Exception e)
        {
            throw new Exception("error on get product",e);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductById(Guid id)
    {
        try
        {
            var product = await _productsService.UpdateProductById(id);
            return Ok(product);
        }
        catch (Exception e)
        {
            throw new Exception("error on update product",e);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProductById(Guid id)
    {
        try
        {
            _productsService.DeleteProductById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("error on delete product",e);
        }
    }
}