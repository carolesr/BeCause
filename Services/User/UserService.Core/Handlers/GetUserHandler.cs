using AutoMapper;
using Foundation.Core.Handler;
using Foundation.Core.Responses;
using System.Threading;
using System.Threading.Tasks;
using UserService.Core.Requests;
using UserService.Repository.Interfaces;

namespace UserService.Core.Handlers
{
    public class GetUserHandler : BaseHandler<GetUserRequest>
    {
        private readonly IUserRepository _repository;

        public GetUserHandler(IMapper mapper, IUserRepository repoitory) : base(mapper)
        {
            _repository = repoitory;
        }

        public override Task<Response> SafeExecuteHandler(GetUserRequest request, CancellationToken cancellationToken)
        {
            return GetUsers(request, cancellationToken);
        }

        public Task<Response> GetUsers(GetUserRequest request, CancellationToken cancellationToken)
        {
            var result = _repository.RetrieveAll();

            Response response = new Response(result);

            return Task.FromResult(response);
        }
    }
}
