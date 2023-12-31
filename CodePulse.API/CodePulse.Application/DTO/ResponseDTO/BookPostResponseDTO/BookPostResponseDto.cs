﻿using CodePulse.Application.DTO.ResponseDTO.CategoryResponseDTO;

namespace CodePulse.Application.DTO.ResponseDTO.BlogPostResponseDTO
{
    public class BookPostResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string UrlHandle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string FeaturedImageUrl { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool IsVisible { get; set; }

        public List<CategoryResponseDto> RCategory{ get; set; } = new List<CategoryResponseDto>();
        //category of each bookpost
    }
}
