namespace CodePulse.Domain.Models
{
    public class BookPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }   = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string FeaturedImageUrl { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsVisible { get; set; }

        public ICollection<Category> RCategory { get; set; } 
    }
}
