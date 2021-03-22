using System;
using UserService.Core.Responses;
using UserService.Core.Requests;
using UserService.Core.Validations;
using UserService.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;

namespace UserService.Core.Handlers
{
    public class CreateUserHandler : BaseHandler<CreateUserRequest> //where T : CreateUserRequest
    {
        IMapper _mapper;
        //UserValidator _validator;

        public CreateUserHandler(IMapper mapper/*, UserValidator validator*/)
        {
            _mapper = mapper;
            //_validator = validator;
        }

        public override Task<Response> SafeExecuteHandler(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return CreateUser(request, cancellationToken);
        }

        public Task<Response> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            var user = _mapper.Map<User>(request);
            //var validation = _validator.Validate(user);
            //if (!validation.IsValid)
            //{
            //    foreach (var failure in validation.Errors)
            //        response = response.AddMessage("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);

            //    return Task.FromResult(response);
            //}

            //user = _service.Create(user);

            var newUser = _mapper.Map<CreateUserResponse>(user);
            newUser.SignUpDate = DateTime.Now;

            response = response.AddObject(newUser);

            return Task.FromResult(response);
        }
    }
}
