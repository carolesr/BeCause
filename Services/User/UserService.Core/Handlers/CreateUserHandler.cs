using System;
using UserService.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using UserService.Core.Requests;
using UserService.Core.Responses;
using Foundation.Core.Handler;
using Foundation.Core.Responses;
using UserService.Repository.Interfaces;

namespace UserService.Core.Handlers
{
    public class CreateUserHandler : BaseHandler<CreateUserRequest>
    {
        private readonly IUserRepository _repository;
        public CreateUserHandler(IMapper mapper, IUserRepository repository) : base(mapper) 
        {
            _repository = repository;
        }

        public override Task<Response> SafeExecuteHandler(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return CreateUser(request, cancellationToken);
        }

        public Task<Response> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            //user = _service.Create(user);
            _repository.Create(user);

            var newUser = _mapper.Map<CreateUserResponse>(user);
            newUser.SignUpDate = DateTime.Now;

            Response response = new Response(newUser);

            return Task.FromResult(response);
        }
    }
}
