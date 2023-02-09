using ImageWorld.Data;
using ImageWorld.Models;

namespace ImageWorld.Api.AppServices.ImageAppService;

public class ImageService : IImageService
{
    private readonly AppDbContext _ctx;
    private readonly IWebHostEnvironment _env;

    public ImageService(AppDbContext ctx, IWebHostEnvironment env)
    {
        _ctx = ctx;
        _env = env;
    }

    public async Task<string> SaveImage(IFormFile image)
    {
        var mime = image.FileName.Split('.').Last();
        var fileName = string.Concat(Path.GetRandomFileName(), ".", mime);
        var savePath = Path.Combine(_env.WebRootPath, fileName);

        await using var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write);
        await image.CopyToAsync(fileStream);

        return fileName;
    }

    public string GetSavePath(string image)
        =>
            Path.Combine(_env.WebRootPath, image);

    
}