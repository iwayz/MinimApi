namespace MinimApi
{
    public interface IArticle
    {
        Task<IResult> Get();
        Task<IResult> Get(int id);
        Task<IResult> Create(ArticleRequest article);
        Task<IResult> Update(int id, ArticleRequest article);
        Task<IResult> Delete(int id);
    }
}
