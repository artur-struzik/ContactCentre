using ContactManager.Requests;

namespace ContactManager.Handlers
{
    public interface IHandler
    {
        IHandler? Next { get; }
        IHandler SetNext(IHandler handler);
        bool Handle(IRequest request);
        void EndRequest(int requestId);
    }
}