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

    // [HttpPost]
    // public async Task<IActionResult> AddProduct([FromBody] CreateProductRequest productDto)
    // {
    //     try
    //     {
    //         var product = await _productsService.AddProduct(productDto);
    //         return Ok(product);
    //     }
    //     catch (Exception e)
    //     {
    //         throw new Exception("error on create product",e);
    //     }
    // }
    //
    // [HttpGet]
    // public async Task<IActionResult> GetProducts()
    // {
    //     try
    //     {
    //         return Ok(await _productsService.GetProducts());
    //     }
    //     catch (Exception e)
    //     {
    //         throw new Exception("error on get product",e);
    //     }
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetProductById(Guid id)
    // {
    //     try
    //     {
    //         var product = await _productsService.GetProductById(id);
    //         return Ok(product);
    //     }
    //     catch (Exception e)
    //     {
    //         throw new Exception("error on get product",e);
    //     }
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateProductById(Guid id, [FromBody] UpdateProductRequest productDto)
    // {
    //     try
    //     {
    //         var product = await _productsService.UpdateProductById(id, productDto);
    //         return Ok(product);
    //     }
    //     catch (Exception e)
    //     {
    //         throw new Exception("error on update product",e);
    //     }
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteProductById(Guid id)
    // {
    //     try
    //     {
    //         await _productsService.DeleteProductById(id);
    //         return NoContent();
    //     }
    //     catch (Exception e)
    //     {
    //         throw new Exception("error on delete product",e);
    //     }
    // }
}