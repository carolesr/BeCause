using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Core.Responses;
using UserService.Core.Requests;

namespace UserService.Core.Handlers
{
    public class BaseHandler : IRequestHandler<Request, Response>
    {
        Task<Response> IRequestHandler<Request, Response>.Handle(Request request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
