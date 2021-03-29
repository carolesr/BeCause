using MediatR;
using System;
using UserService.Core.Responses;

namespace UserService.Core.Requests
{
    public class CreateUserRequest : Request
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string Picture { get; set; }
    }
}
