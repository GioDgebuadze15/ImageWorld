using System.Linq.Expressions;
using ImageWorld.Models;

namespace ImageWorld.Api.ViewModels;

public static class PostViewModels
{
    public static Expression<Func<Post, object>> Default =>
        post => new
        {
            post.Id,
            post.Title,
            post.ImageName,
            post.Content,
            Categories = post.PostCategories.Select(x => new
            {
                x.Category.Id,
                x.Category.Deleted
            })
        };
}