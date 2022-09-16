using Microsoft.EntityFrameworkCore;
using MinimApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("api"));
builder.Services.AddScoped<IArticle, ArticleService>();

var app = builder.Build();

// routing root
app.MapGet("/", () => "App is running.");

// routing articles
app.MapGet("/articles", async (IArticle articleService) => await articleService.Get());
app.MapGet("/articles/{id}", async (int id, IArticle articleService) => await articleService.Get(id));
app.MapPost("/articles", async (ArticleRequest articleRequest, IArticle articleSercvice) => await articleSercvice.Create(articleRequest));
app.MapPut("/articles/{id}", async (int id, ArticleRequest articleRequest, IArticle articleSercvice) => await articleSercvice.Update(id, articleRequest));
app.MapDelete("/articles/{id}", async (int id, IArticle articleService) => await articleService.Delete(id));

app.Run();
