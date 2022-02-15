using ContactManager.Handlers;
using ContactManager.Requests;

namespace ContactManager
{
    public class RouteRequest : IRouteRequest
    {
        private IHandler handler;
        public RouteRequest(IHandler handler, IHandlerValidator handlerValidator)
        {
            handlerValidator.Validate(handler);
            this.handler = handler;
        }

        public bool DispatchRequest(IRequest request)
        {
            return handler.Handle(request);
        }

        public void EndRequest(int requestId)
        {
            handler.EndRequest(requestId);
        }
    }
}