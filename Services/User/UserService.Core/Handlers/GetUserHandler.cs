using AutoMapper;
using Foundation.Core.Handler;
using Foundation.Core.Responses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UserService.Core.Requests;
using UserService.Core.Services.Interfaces;

namespace UserService.Core.Handlers
{
    public class GetUserHandler : BaseHandler<GetUserRequest>
    {
        private readonly IUserService _service;

        public GetUserHandler(IMapper mapper, IUserService service) : base(mapper)
        {
            _service = service;
        }

        public override Task<Response> SafeExecuteHandler(GetUserRequest request, CancellationToken cancellationToken)
        {
            return GetUsers(request, cancellationToken);
        }

        public Task<Response> GetUsers(GetUserRequest request, CancellationToken cancellationToken)
        {
            var result = _service.GetAllUsers(request.ActiveOnly);

            Response response = new Response(result);

            return Task.FromResult(response);
        }
    }
}
