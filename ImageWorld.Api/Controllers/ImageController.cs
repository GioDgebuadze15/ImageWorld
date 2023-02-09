using ImageWorld.Api.AppServices.ImageAppService;
using Microsoft.AspNetCore.Mvc;

namespace ImageWorld.Api.Controllers;

[Route("api/image")]
public class ImageController : ControllerBase
{
    private readonly IImageService _iImageService;

    public ImageController(IImageService iImageService)
    {
        _iImageService = iImageService;
    }

    [HttpGet("{image}")]
    public IActionResult GetImage(string image)
    {
        var savePath = _iImageService.GetSavePath(image);
        return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read), "image/*");
    }
    

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile image)
        =>
            Ok(await _iImageService.SaveImage(image));
    
}