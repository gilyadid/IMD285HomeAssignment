using IMD285WebAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IMD285WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ILogger<CategoriesController> _logger;
    private readonly Imd285DbContext _dbContext;

    public CategoriesController(
        ILogger<CategoriesController> logger,
        Imd285DbContext md285DbContext)
    {
        _logger = logger;
        _dbContext = md285DbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Category>> GetCategories()
    {
        var result = await _dbContext.Categories.ToListAsync();
        _logger.Log(LogLevel.Information, "GetCategories() Fetched {Categories}", result);
        return result;
    }
}
