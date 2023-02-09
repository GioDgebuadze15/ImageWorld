using ImageWorld.Api.AppServices.CategoryAppService;
using ImageWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace ImageWorld.Api.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _iCategoryService;

    public CategoryController(ICategoryService iCategoryService)
    {
        _iCategoryService = iCategoryService;
    }

    [HttpGet]
    public IEnumerable<Category> All() => _iCategoryService.GetAllCategories();
    
    [HttpGet("{id}")]
    public Category? Get(string id) => _iCategoryService.GetCategory(id);

    [HttpGet("{id}/posts")]
    public IEnumerable<Post> ListPostsForCategory(string id)
        => _iCategoryService.GetPostsForCategory(id); 
}