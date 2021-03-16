using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using UserService.Core.Handlers;
using UserService.Core.Mappers;
using UserService.Core.Requests;
using UserService.Core.Responses;
using UserService.Core.Validations;
using MediatR;

namespace UserService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) : base (mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates new User.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A newly created User</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet]
        public ActionResult CreateUser(CreateUserRequest request)
        {

            var response = this.Handle(request);

            return response;            
        }
    }
}
