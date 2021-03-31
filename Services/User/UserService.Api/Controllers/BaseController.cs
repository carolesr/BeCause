using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using UserService.Core.Requests;
using UserService.Core.Responses;

namespace UserService.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Handle(Request request)
        {
            try
            {
                var response = await _mediator.Send(request);

                if (response == null || !response.Success)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new Response(ex.Message, false));
            }
        }
    }
}
