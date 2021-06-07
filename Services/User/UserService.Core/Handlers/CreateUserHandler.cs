using System;
using UserService.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using UserService.Core.Requests;
using UserService.Core.Responses;
using Foundation.Core.Handler;
using Foundation.Core.Responses;
using UserService.Core.Services.Interfaces;

namespace UserService.Core.Handlers
{
    public class CreateUserHandler : BaseHandler<CreateUserRequest>
    {
        private readonly IUserService _service;

        public CreateUserHandler(IMapper mapper, IUserService service) : base(mapper) 
        {
            _service = service;
        }

        public override Task<Response> SafeExecuteHandler(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return CreateUser(request, cancellationToken);
        }

        public Task<Response> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            var response = _service.CreateUser(user);

            if (response.Success)
            {
                var newUser = _mapper.Map<CreateUserResponse>(user);
                newUser.SignUpDate = DateTime.Now;
                response.AddResult(newUser);
            }

            return Task.FromResult(response);
        }
    }
}
