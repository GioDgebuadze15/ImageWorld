using System.Linq.Expressions;
using ImageWorld.Models;

namespace ImageWorld.Api.ViewModels;

public static class PostViewModels
{
    public static Expression<Func<Post, object>> Default =>
        post => new
        {
            post.Id,
            post.ImageName,
            post.Content,
            Categories = post.PostCategories.Select(x => x.CategoryId)
        };
}