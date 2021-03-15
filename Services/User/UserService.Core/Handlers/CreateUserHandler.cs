using System;
using UserService.Core.Responses;
using UserService.Core.Requests;
using UserService.Core.Validations;
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
        UserValidator _validator;

        public CreateUserHandler(IMapper mapper, UserValidator validator) 
        {
            _mapper = mapper;
            _validator = validator;
        }

        public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var validation = _validator.Validate(user);

            if (!validation.IsValid)
            {
                foreach (var failure in validation.Errors)
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                //return Exception;
            }

            //user = _service.Create(user);

            var response = _mapper.Map<CreateUserResponse>(user);
            response.SignUpDate = DateTime.Now;

            return Task.FromResult(response);            
        }
    }
}
