using ImageWorld.Models;

namespace ImageWorld.Api.AppServices.CategoryAppService;

public interface ICategoryService
{
    IEnumerable<Post> GetPostsForCategory(string id);
    IEnumerable<Category> GetAllCategories();
    Category? GetCategory(string id);
}