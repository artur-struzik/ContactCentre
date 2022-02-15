using ContactManager.Handlers;

namespace ContactManager.Requests
{
    public interface IRequest
    {
        int Id { get; }
        RequestType Type { get; }
        IHandler? Handler { get; set; }
    }
}