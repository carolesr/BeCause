using System;
using System.Collections.Generic;
using System.Text;

using MediatR;

namespace UserService.Core.Responses
{
    public class CreateUserResponse/* : IRequest<CreateUserResponse>*/
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime SignUpDate { get; set; }
    }
}
