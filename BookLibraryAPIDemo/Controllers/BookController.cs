using BookLibraryAPIDemo.Application.Commands.Books;
using BookLibraryAPIDemo.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPIDemo.API.Controllers
{
    [Authorize]
    public class BookController : BaseApiController
    {


        public async Task<IActionResult> CreateBookAsync([FromBody] BookDTO model)
        {
            return Ok(await Mediator.Send(new CreateBook { Book = model }));
        }
    }
}
