﻿namespace CodePulse.Application.DTO.RequestDTO
{
    public class GetCategoryRequestDTO
    {
        public Guid Id { get; set; }
        public string UrlHandle { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
