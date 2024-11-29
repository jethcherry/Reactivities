using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This sets the route prefix to "api/activities"
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator=> _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
