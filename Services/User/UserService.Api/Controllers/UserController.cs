using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Foundation.Api.Controllers;
using UserService.Core.Requests;

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
