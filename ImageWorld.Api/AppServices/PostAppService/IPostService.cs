using ImageWorld.Api.Form;

namespace ImageWorld.Api.AppServices.PostAppService;

public interface IPostService
{
    Task<object> CreatePost(PostForm postForm);
    IEnumerable<object> GetAllPosts();
    object? GetPost(int id);
}