using AutoMapper;
using GymApi.Data.Data;
using GymApi.Domain;
using GymApi.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace GymUserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly GymDbContext _context;
    private readonly IMapper _mapper;

    public ProductsController(GymDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddProduct([FromBody] AddProductRequest productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        _context.Products.Add(product);
        _context.SaveChanges();
        return Ok(product);
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_context.Products.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(Guid id)
    {
        var product = _context.Products.FirstOrDefault(product => product.Id == id);
        if(product == null) return NotFound();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProductById(Guid id)
    {
        var product = _context.Products.FirstOrDefault(product => product.Id == id);
        if (product == null) return NotFound();

        _context.Remove(product);
        _context.SaveChanges();
        return Ok(product);
    }
}