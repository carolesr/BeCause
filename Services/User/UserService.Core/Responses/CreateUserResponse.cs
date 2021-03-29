using System;
using System.Collections.Generic;
using System.Text;

using MediatR;

namespace UserService.Core.Responses
{
    public class CreateUserResponse : IRequest
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string CPF { get; set; }
        public string Picture { get; set; }
        public DateTime SignUpDate { get; set; }
    }
}
