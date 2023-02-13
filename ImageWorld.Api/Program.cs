using IdentityServer4.Models;
using ImageWorld.Api.AppServices.CategoryAppService;
using ImageWorld.Api.AppServices.ImageAppService;
using ImageWorld.Api.AppServices.PostAppService;
using ImageWorld.Data;
using ImageWorld.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

const string allCors = "All";

var builder = WebApplication.CreateBuilder(args);

AddIdentity();

builder.Services.AddControllers();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Dev"));
builder.Services.AddDbContext<IdentityDbContext>(options => options.UseInMemoryDatabase("DevIdentity"));

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

        var userManger = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var user = new IdentityUser("test");
        userManger.CreateAsync(user, "password").GetAwaiter().GetResult();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(allCors);
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();

    endpoints.MapRazorPages();
});

app.Run();


void AddIdentity()
{
    builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            if (builder.Environment.IsDevelopment())
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }
            else
            {
                options.Password.RequiredLength = 8;
            }
        })
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(config => { config.LoginPath = "/Account/Login"; });

    var identityServerBuilder = builder.Services.AddIdentityServer();

    identityServerBuilder.AddAspNetIdentity<IdentityUser>();

    if (builder.Environment.IsDevelopment())
    {
        identityServerBuilder.AddInMemoryIdentityResources(new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        });

        identityServerBuilder.AddInMemoryClients(new Client[]
        {
            new()
            {
                ClientId = "vue-client",
                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = new[] {"http://localhost:5173"},
                PostLogoutRedirectUris = new[] {"http://localhost:5173"},
                AllowedCorsOrigins = new[] {"http://localhost:5173"},

                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,
                RequireClientSecret = false,
            }
        });

        identityServerBuilder.AddDeveloperSigningCredential();
    }
}