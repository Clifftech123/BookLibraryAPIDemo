using BookLibraryAPIDemo.Application.Commands.Books;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Queries.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPIDemo.API.Controllers
{
    //[Authorize]
    public class BookController : BaseApiController
    {


        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookDTO model)
        {
            return Ok(await Mediator.Send(new CreateBook { Book = model }));
        }

        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetBooksAsync()
        {
            return Ok(await Mediator.Send(new GetAllBook()));
        }

        [HttpGet("books/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new GetBookById() { BookId = id }));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookAsync([FromBody] BookDTO model)
        {
            return Ok(await Mediator.Send(new UpdateBook { Book = model }));
        }

        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteBook { BookId = id }));
        }
    }
}
