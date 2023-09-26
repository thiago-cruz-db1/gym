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
        var product = _productsService.AddProduct(productDto);
        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productsService.GetProducts());
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(Guid id)
    {
        var product = _productsService.GetProductById(id);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProductById(Guid id)
    {
        _productsService.DeleteProductById(id);
        return NoContent();
    }
}