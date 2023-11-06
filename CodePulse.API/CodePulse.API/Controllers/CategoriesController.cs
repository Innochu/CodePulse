using CodePulse.Application.DTO.RequestDTO;
using CodePulse.Domain.Models;
using CodePulse.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    //hhtps: localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoriesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //https: localhost: xxxx/api/createCategories
        [HttpPost]
        public async Task<IActionResult> CreatCategory(PostCategoryRequestDTO postCategoryRequestDTO)
        {
            // map DTO to Domain Model

            var cat = new Category
            {
                Name = postCategoryRequestDTO.Name,
                Urlhandle = postCategoryRequestDTO.Urlhandle,
            };

            await _applicationDbContext.SaveChangesAsync();
            return Ok(cat);
        }
    }
}
