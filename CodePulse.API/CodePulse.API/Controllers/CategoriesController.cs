using CodePulse.Application.DTO.RequestDTO;
using CodePulse.Application.DTO.ResponseDTO;
using CodePulse.Application.Interfaces;
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
        private readonly ICategoryRepo _categoryRepo;

        public CategoriesController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        //https: localhost: xxxx/api/createCategories
        [HttpPost]
        public async Task<IActionResult> CreatCategory(PostCategoryRequestDTO postCategoryRequestDTO)
        {

            // map DTO to Domain Model

            var category = new Category   //ensure variable name of this mapping is == variable name passed in your repo look for *** in repo
            {
                Name = postCategoryRequestDTO.Name,
                Urlhandle = postCategoryRequestDTO.Urlhandle,
            };

            await _categoryRepo.CreateAsync(category);

            //map Domain model to DTO

            var response = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.Urlhandle,
                //this mapping is what would display in our swagger UI
            };


            return Ok(response);   //you have to return the DTO response
        }
    }
}
