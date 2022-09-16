namespace MinimApi
{
    using Microsoft.EntityFrameworkCore;

    public class ArticleService : IArticle
    {
        public readonly ApiContext _context;

        public ArticleService(ApiContext context)
        {
            _context = context;
        }

        public async Task<IResult> Create(ArticleRequest article)
        {
            var articleToCreate = new Article
            {
                Title = article.Title,
                Content = article.Content,
                PublishedAt = article.PublishedAt
            };
            var createdArticle = _context.Articles.Add(articleToCreate);

            await _context.SaveChangesAsync();

            return Results.Created($"/articles/{createdArticle.Entity.Id}", createdArticle.Entity);
        }

        public async Task<IResult> Delete(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return Results.NotFound("Data not found. No data deleted.");
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();

            return Results.NoContent();
        }

        public async Task<IResult> Get()
        {
            return Results.Ok(await _context.Articles.ToListAsync());
        }

        public async Task<IResult> Get(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            return article != null ? Results.Ok(article) : Results.NotFound("Data not found.");
        }

        public async Task<IResult> Update(int id, ArticleRequest article)
        {
            var articleToUpdate = await _context.Articles.FindAsync(id);

            if (articleToUpdate == null)
            {
                return Results.NotFound("Data not found. No data updated.");
            }

            if (article.Title != null)
            {
                articleToUpdate.Title = article.Title;
            }

            if (article.Content != null)
            {
                articleToUpdate.Content = article.Content;
            }

            if (article.PublishedAt != null)
            {
                articleToUpdate.PublishedAt = article.PublishedAt;
            }

            await _context.SaveChangesAsync();

            return Results.Ok(articleToUpdate);
            
        }
    }
}

