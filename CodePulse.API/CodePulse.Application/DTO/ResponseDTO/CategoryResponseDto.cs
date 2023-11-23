using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePulse.Application.DTO.ResponseDTO
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }
        public string UrlHandle { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
