﻿using System.ComponentModel.DataAnnotations;

namespace CodePulse.Application.DTO.RequestDTO.CategoryRequestDTO
{
    public class UpdateCategoryRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Urlhandle { get; set; } = string.Empty;

    }
}
