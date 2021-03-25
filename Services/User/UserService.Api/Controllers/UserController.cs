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
using System.Threading.Tasks;

namespace UserService.Api.Controllers
{
    [ApiController]
    [Route("User")]
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
        ///// <param name="request"></param>
        /// <returns>A newly created User</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpGet]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser()
        {
            var request = new CreateUserRequest { Name="robson", Email = "email@email", Phone = 999999999 };
            var response = await this.Handle(request);

            return response;            
        }
    }
}
