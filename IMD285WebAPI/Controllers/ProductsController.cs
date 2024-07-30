using IMD285WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMD285WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController
{
    private readonly ILogger<ProductsController> _logger;
    private readonly Imd285DbContext _dbContext;

    public ProductsController(
        ILogger<ProductsController> logger,
        Imd285DbContext md285DbContext)
    {
        _logger = logger;
        _dbContext = md285DbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetProducts(Guid categoryId)
    {
        var result = await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        _logger.Log(LogLevel.Information, "GetProducts({CategoryId}) Fetched {Products}", categoryId, result);
        return result;
    }
}
