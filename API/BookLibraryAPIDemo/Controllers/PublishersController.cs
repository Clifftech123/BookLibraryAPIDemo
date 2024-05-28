using BookLibraryAPIDemo.API.Controllers;
using BookLibraryAPIDemo.Application.Commands.Publishers;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Queries.Publishers;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPIDemo.Controllers
{
    // [Authorize]
    public class PublishersController : BaseApiController
    {
        [HttpPost("CreatePublisher")]
        public async Task<IActionResult> CreatePublisherAsync([FromBody] PublisherDTO model)
        {

            return Ok(await Mediator.Send(new CreatePublisher { Publisher = model }));
        }

        [HttpGet("GetAllPublishers")]
        public async Task<IActionResult> GetPublishersAsync()
        {

            return Ok(await Mediator.Send(new GetAllPublisher()));
        }

        [HttpGet("publishers/{id}")]
        public async Task<IActionResult> GetPublisherByIdAsync(int id)
        {

            return Ok(await Mediator.Send(new GetPublisherById() { PublisherId = id }));
        }

        [HttpPut("UpdatePublisher")]
        public async Task<IActionResult> UpdatePublisherAsync([FromBody] PublisherDTO model)
        {

            return Ok(await Mediator.Send(new UpdatePublisher { publisher = model }));
        }

        [HttpDelete("publishers/{id}")]
        public async Task<IActionResult> DeletePublisherAsync([FromRoute] int id)
        {

            return Ok(await Mediator.Send(new DeletePublisher { publisherId = id }));
        }
    }
}
