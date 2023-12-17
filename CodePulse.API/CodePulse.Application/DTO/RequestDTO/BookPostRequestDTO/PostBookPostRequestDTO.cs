﻿namespace CodePulse.Application.DTO.RequestDTO.BlogPostRequestDTO
{
    public class PostBookPostRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string FeaturedImageUrl { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsVisible { get; set; }
        public Guid[] RCategory { get; set; } 

    }
}
