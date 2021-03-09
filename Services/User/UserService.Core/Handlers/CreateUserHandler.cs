using System;
using UserService.Core.Responses;
using UserService.Core.Requests;
using UserService.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace UserService.Core.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public CreateUserHandler() { }

        public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = "foolano",
                Email = "foo@lano.com",
                Phone = 99999999
            };

            //_service.Create(user);

            var response = new CreateUserResponse
            {
                IdUser = user.IdUser,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                SignUpDate = DateTime.Now
            };

            return Task.FromResult(response);
        }
    }
}
