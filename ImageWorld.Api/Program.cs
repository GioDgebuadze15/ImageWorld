using ImageWorld.Api.AppServices.CategoryAppService;
using ImageWorld.Api.AppServices.ImageAppService;
using ImageWorld.Api.AppServices.PostAppService;
using ImageWorld.Data;
using ImageWorld.Models;
using Microsoft.EntityFrameworkCore;

const string allCors = "All";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Dev"));

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddCors(options =>
    options.AddPolicy(allCors, build =>
        build.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (app.Environment.IsDevelopment())
    {
        ctx.Add(new Category {Id = "Adventure"});
        ctx.Add(new Category {Id = "Sport"});
        ctx.Add(new Category {Id = "Nature"});
        ctx.Add(new Category {Id = "Programming"});
        ctx.Add(new Category {Id = "Movie"});
        ctx.Add(new Post
        {
            Title = "Vue",
            ImageName = "vue.png",
            Content = "This is a post about Vue.js",
            PostCategories = new List<PostCategory> {new() {CategoryId = "Programming"}}
        });
        ctx.Add(new Post
        {
            Title = ".Net",
            ImageName = "dotnet.png",
            Content = "This is a post about .Net",
            PostCategories = new List<PostCategory> {new() {CategoryId = "Programming"}}
        });
        ctx.Add(new Post
        {
            Title = "Java",
            ImageName = "java.png",
            Content = "This is a post about Java",
            PostCategories = new List<PostCategory> {new() {CategoryId = "Programming"}}
        });
        ctx.Add(new Post
        {
            Title = "Movies",
            ImageName = "movies.png",
            Content = "This is a post about Movies",
            PostCategories = new List<PostCategory> {new() {CategoryId = "Movie"}}
        });

        ctx.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(allCors);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();