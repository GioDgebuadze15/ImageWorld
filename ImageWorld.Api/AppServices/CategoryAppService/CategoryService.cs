using ImageWorld.Data;
using ImageWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageWorld.Api.AppServices.CategoryAppService;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _ctx;

    public CategoryService(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public IEnumerable<Post> GetPostsForCategory(string id)
        => _ctx.PostCategories
            .Include(x => x.Post)
            .Where(x => x.CategoryId.Equals(id, StringComparison.InvariantCultureIgnoreCase))
            .Select(x => x.Post)
            .ToList();

    public IEnumerable<Category> GetAllCategories()
        => _ctx.Categories.ToList();

    public Category? GetCategory(string id)
        => _ctx.Categories.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
}