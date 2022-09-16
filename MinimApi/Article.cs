namespace MinimApi
{
    public class Article
    {
        public int Id { get; init; }

        public string Title { get; set; } = String.Empty;
        
        public string Content { get; set; } = String.Empty;
        
        public DateTime? PublishedAt { get; set; }
    }
}
