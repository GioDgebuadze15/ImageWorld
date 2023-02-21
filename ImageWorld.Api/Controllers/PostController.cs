using IdentityServer4;
using ImageWorld.Api.AppServices.PostAppService;
using ImageWorld.Api.Form;
using ImageWorld.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageWorld.Api.Controllers;

[ApiController]
[Route("api/post")]
public class PostController : ControllerBase
{
    private readonly IPostService _iPostService;

    public PostController(IPostService iPostService)
    {
        _iPostService = iPostService;
    }

    [HttpGet("test")]
    [Authorize(Policy = IdentityServerConstants.LocalApi.PolicyName)]
    public string TestAuth() => "test";


    [HttpGet]
    public IEnumerable<object> All()
        =>
            _iPostService.GetAllPosts();
    
    [HttpGet("{id::int}")]
    public object? Get(int id)
        =>
            _iPostService.GetPost(id);


    [HttpPost]
    public async Task<object> Create([FromBody] PostForm postForm)
        =>
            Ok(await _iPostService.CreatePost(postForm));
} 