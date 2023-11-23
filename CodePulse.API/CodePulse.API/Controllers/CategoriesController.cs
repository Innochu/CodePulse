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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

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
        [HttpPost("Add-Category")]
        public async Task<IActionResult> CreatCategory([FromBody]PostCategoryRequestDTO postCategoryRequestDTO)
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


        //GET: https://localhost:7278/api/Categories/Get-All
        [HttpGet("Get-All")]
        public async Task<IActionResult> Getcategory()
        {
          var categories =   await _categoryRepo.GetAllAsync();


            //categories is a variable carring the properties of the repositories including the models
            //since we know that REPO deals with only model classes, and controller deals
            //with only DTO, therefore.....
            //map Domain model to DTO



            var response = new List<CategoryResponseDto>();

            //the list is declared is an empty list, so we need to add it members


            foreach (var item in categories)
            {
                response.Add(new CategoryResponseDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    UrlHandle = item.Urlhandle,
                }
                    );
            }

            return Ok(response);
            //returns the Dto to the user
        }
    }
}
