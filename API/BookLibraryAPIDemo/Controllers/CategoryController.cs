using BookLibraryAPIDemo.API.Controllers;
using BookLibraryAPIDemo.Application.Commands.BookLibraryAPICategory;
using BookLibraryAPIDemo.Application.Commands.Categorys;
using BookLibraryAPIDemo.Application.DTO;
using BookLibraryAPIDemo.Application.Queries.BookLibraryAPICategory;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPIDemo.Controllers
{
    // [Authorize]
    public class CategoryController : BaseApiController
    {

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDTO model)
        {
            return Ok(await Mediator.Send(new CreateCategory { Category = model }));
        }



        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            return Ok(await Mediator.Send(new GetAllCategories()));
        }


        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {

            return Ok(await Mediator.Send(new GetCategoryById() { CategoryId = id }));
        }


        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] UpdateCategoryDTO model)
        {
            return Ok(await Mediator.Send(new UpdateCategory { Id = id, Category = model }));
        }


        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
        {

            return Ok(await Mediator.Send(new DeleteCategory { CategoryId = id }));
        }
    }
}
