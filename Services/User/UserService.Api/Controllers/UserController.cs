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
        public UserController(IMediator mediator) : base (mediator) { }

        /// <summary>
        /// Creates new User.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A newly created User</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">Request object did not succeded validation or some error occured</response> 
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            return await this.Handle(request);
        }
    }
}
