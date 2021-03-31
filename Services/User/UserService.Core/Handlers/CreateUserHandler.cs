using System;
using UserService.Core.Responses;
using UserService.Core.Requests;
using UserService.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace UserService.Core.Handlers
{
    public class CreateUserHandler : BaseHandler<CreateUserRequest>
    {
        IMapper _mapper;

        public CreateUserHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override Task<Response> SafeExecuteHandler(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return CreateUser(request, cancellationToken);
        }

        public Task<Response> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {

            var user = _mapper.Map<User>(request);

            //user = _service.Create(user);

            var newUser = _mapper.Map<CreateUserResponse>(user);
            newUser.SignUpDate = DateTime.Now;

            Response response = new Response(newUser);

            return Task.FromResult(response);
        }
    }
}
