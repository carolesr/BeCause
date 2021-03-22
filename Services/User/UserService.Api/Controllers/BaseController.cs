using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserService.Core.Requests;

namespace UserService.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult Handle(Request request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}
