using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryAPIDemo.API.Controllers
{
    public class BaseApiController: ControllerBase
    {
        protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();


    }
}
