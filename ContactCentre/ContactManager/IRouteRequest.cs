using ContactManager.Requests;

namespace ContactManager
{
    public interface IRouteRequest
    {
        bool DispatchRequest(IRequest request);
        void EndRequest(int requestId);
    }
}