using CodePulse.Application.DTO.RequestDTO.BlogPostRequestDTO;
using CodePulse.Application.DTO.RequestDTO.CategoryRequestDTO;
using CodePulse.Application.DTO.ResponseDTO;
using CodePulse.Domain.Models;
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
    public class BlogPostController : ControllerBase
    {


        [HttpPost("Add-Category")]
        public async Task<IActionResult> CreatCategory([FromBody] PostBookPostRequestDTO postBookPostRequestDTO)
        {

            // map DTO to Domain Model

            var bookPost = new BookPost   //ensure variable name of this mapping is == variable name passed in your repo look for *** in repo
            {
                Title = postBookPostRequestDTO.Title,
               ShortDescription = postBookPostRequestDTO.ShortDescription,
               Author = postBookPostRequestDTO.Author,
               UrlHandle = postBookPostRequestDTO.UrlHandle,
               Content = postBookPostRequestDTO.Content,
               FeaturedImageUrl = postBookPostRequestDTO.FeaturedImageUrl,
               DateCreated = postBookPostRequestDTO.DateCreated,
               IsVisible = postBookPostRequestDTO.IsVisible,


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
