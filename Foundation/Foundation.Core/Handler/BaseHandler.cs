using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Foundation.Core.Requests;
using Foundation.Core.Responses;
using MediatR;

namespace Foundation.Core.Handler
{
    public abstract class BaseHandler<T> : IRequestHandler<T, Response> where T : Request
    {
        protected IMapper _mapper;
        public BaseHandler(IMapper mapper) 
        {
            _mapper = mapper;
        }

        public async Task<Response> Handle(T request, CancellationToken cancellationToken)
        {
            try
            {
                return await SafeExecuteHandler(request, cancellationToken);
            }
            catch (Exception e)
            {
                return new Response(e.Message);
            }
        }

        public abstract Task<Response> SafeExecuteHandler(T request, CancellationToken cancellationToken);
    }
}
