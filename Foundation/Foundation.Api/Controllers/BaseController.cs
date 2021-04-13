using System;
using Foundation.Core.Requests;
using Foundation.Core.Responses;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Api.Controllers
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
