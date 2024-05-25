using BookLibraryAPIDemo.API.Controllers;
using BookLibraryAPIDemo.Application.Commands.Authors;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Queries.Authors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPIDemo.Controllers
{
    [Authorize]
    public class AuthorsController : BaseApiController
    {
        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateAuthorAsync([FromBody] AuthorDTO model)
        {
            // Replace 'CreateAuthor' with your actual command
            return Ok(await Mediator.Send(new CreateAuthor { Author = model }));
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            // Replace 'GetAllAuthors' with your actual query
            return Ok(await Mediator.Send(new GetAllAuthors()));
        }

        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(int id)
        {
            // Replace 'GetAuthorById' with your actual query
            return Ok(await Mediator.Send(new GetAuthorById() { AuthorId = id }));
        }

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorDTO model)
        {
            // Replace 'UpdateAuthor' with your actual command
            return Ok(await Mediator.Send(new UpdateAuthor { Author = model }));
        }

        [HttpDelete("authors/{id}")]
        public async Task<IActionResult> DeleteAuthorAsync([FromRoute] int id)
        {
            // Replace 'DeleteAuthor' with your actual command
            return Ok(await Mediator.Send(new DeleteAuthor { AuthorId = id }));
        }
    }
}
