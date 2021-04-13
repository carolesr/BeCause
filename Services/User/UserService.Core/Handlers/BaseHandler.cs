//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using MediatR;
//using UserService.Core.Responses;
//using UserService.Core.Requests;

//namespace UserService.Core.Handlers
//{
//    public abstract class BaseHandler<T> : IRequestHandler<T, Response> where T : Request
//    {
//        public BaseHandler() { }
        
//        public async Task<Response> Handle(T request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                return await SafeExecuteHandler(request, cancellationToken);
//            }
//            catch (Exception e)
//            {
//                return new Response(e.Message);
//            }
//        }

//        public abstract Task<Response> SafeExecuteHandler(T request, CancellationToken cancellationToken) ;
//    }
//}
