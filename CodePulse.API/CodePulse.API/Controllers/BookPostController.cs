﻿using CodePulse.Application.DTO.RequestDTO.BlogPostRequestDTO;
using CodePulse.Application.DTO.RequestDTO.CategoryRequestDTO;
using CodePulse.Application.DTO.ResponseDTO;
using CodePulse.Application.DTO.ResponseDTO.BlogPostResponseDTO;
using CodePulse.Application.DTO.ResponseDTO.CategoryResponseDTO;
using CodePulse.Application.Interfaces;
using CodePulse.Domain.Models;
using CodePulse.Infrastructure.RepositoryFolder;
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
    public class BookPostController : ControllerBase
    {
        private readonly IBookPostRepo _bookPostRepo;

        public BookPostController(IBookPostRepo bookPostRepo)
        {
            _bookPostRepo = bookPostRepo;
        }

        [HttpPost("Add-BookPost")]
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

            await _bookPostRepo.CreateAsync(bookPost);

            //map Domain model to DTO

            var response = new BookPostResponseDto
            {
                Id = bookPost.Id,
                Title = bookPost.Title,
                ShortDescription = bookPost.ShortDescription,
                Author = bookPost.Author,
                UrlHandle = bookPost.UrlHandle,
                Content = bookPost.Content,
                FeaturedImageUrl = bookPost.FeaturedImageUrl,
                DateCreated = bookPost.DateCreated,
                IsVisible = bookPost.IsVisible,
                //this mapping is what would display in our swagger UI
            };


            return Ok(response);   //you have to return the DTO response
        }





        //GET: https://localhost:7278/api/BookPost/Get-All-Books
        [HttpGet("Get-All-Books")]
        public async Task<IActionResult> Getcategory()
        {
            var books = await _bookPostRepo.GetAllAsync();


            //categories is a variable carring the properties of the repositories including the models
            //since we know that REPO deals with only model classes, and controller deals
            //with only DTO, therefore.....
            //map Domain model to DTO



            var response = new List<BookPostResponseDto>();

            //the list is declared is an empty list, so we need to add it members


            foreach (var item in books)
            {
                response.Add(new BookPostResponseDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    ShortDescription= item.ShortDescription,
                    Author = item.Author,
                    UrlHandle = item.UrlHandle,
                    Content = item.Content,
                    FeaturedImageUrl = item.FeaturedImageUrl,
                    DateCreated = item.DateCreated,
                    IsVisible = item.IsVisible,

                   
                }
                    );
            }

            return Ok(response);
            //returns the Dto to the user
        }


    }
}