using System;
using UserService.Core.Responses;
using UserService.Core.Requests;
using UserService.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace UserService.Core.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        IMapper _mapper;

        public CreateUserHandler(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            //user = _service.Create(user);

            var response = _mapper.Map<CreateUserResponse>(user);
            response.SignUpDate = DateTime.Now;

            return Task.FromResult(response);
        }
    }
}
