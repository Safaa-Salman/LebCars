using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        //If Mediator is Null asign to it whatever is on the right
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
        .GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return NotFound();
            if(result.IsSucess && result.Value != null)
                return Ok(result.Value);
            if(result.IsSucess && result.Value == null)
                return NotFound();
            return BadRequest(result.Error);
        }
        
    }
}