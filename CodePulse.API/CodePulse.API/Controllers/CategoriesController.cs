using CodePulse.Application.DTO.RequestDTO.CategoryRequestDTO;
using CodePulse.Application.DTO.ResponseDTO.CategoryResponseDTO;
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

        //Get https://localhost:7278/api/Categories/GetById
        [HttpGet("GetById{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
           var getbyid = await _categoryRepo.GetByIdAsync(id);

            if (getbyid == null)
            {
                return BadRequest();
            }
            return Ok(getbyid);

            
        }


        [HttpPut("Update{id:Guid}")]
        public async Task<IActionResult> update([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDTO updateCategoryRequestDTO)
        {
            var cat = new Category()
            {
                Id = id,
                Name = updateCategoryRequestDTO.Name,
                Urlhandle = updateCategoryRequestDTO.Urlhandle,
            };
            
             cat = await _categoryRepo.UpdateAsync(cat);

            if (cat == null)
            {
                return NotFound();
            }

            var response = new CategoryResponseDto
            {
                Id = cat.Id,
                Name = cat.Name,
                UrlHandle = cat.Urlhandle,
            };

            return Ok(response);

          
        }

        [HttpDelete("Delete{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
         var del =   await _categoryRepo.DeleteAsync(id);

            if(del == null)
            {
                return NotFound(id);
            }


            var response = new CategoryResponseDto
            
            {
                Id = del.Id,
                Name = del.Name,
                UrlHandle = del.Urlhandle,
            };
            return Ok(response);
        }

    }
}
