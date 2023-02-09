using ImageWorld.Models;

namespace ImageWorld.Api.AppServices.ImageAppService;

public interface IImageService
{
    Task<string> SaveImage(IFormFile image);
    string GetSavePath(string image);

}