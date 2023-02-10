using ImageWorld.Api.Form;
using ImageWorld.Api.ViewModels;
using ImageWorld.Data;
using ImageWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageWorld.Api.AppServices.PostAppService;

public class PostService : IPostService
{
    private readonly AppDbContext _ctx;

    public PostService(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<object> CreatePost(PostForm postForm)
    {
        var post = new Post
        {
            Title = postForm.Title,
            ImageName = postForm.ImageName,
            Content = postForm.Content,
            PostCategories = _ctx.Categories
                .Where(c => postForm.Categories.Contains(c.Id))
                .Select(c => new PostCategory
                {
                    CategoryId = c.Id,
                    Category = c
                }).ToList()
        };
        _ctx.Add(post);
        await _ctx.SaveChangesAsync();
        var a = PostViewModels.Default.Compile().Invoke(post);
        return a;
    }

    public IEnumerable<object> GetAllPosts()
        => _ctx.Posts.Select(PostViewModels.Default).ToList();

    public object? GetPost(int id)
        => _ctx.Posts
            .Where(x => x.Id.Equals(id))
            .Select(PostViewModels.Default)
            .FirstOrDefault();
}