using ContactManager.Handlers;

namespace ContactManager.Requests
{
    public class Request : IRequest
    {
        private readonly int id;
        private readonly RequestType type;

        public Request(int id, RequestType type)
        {
            this.id = id;
            this.type = type;
        }

        public IHandler? Handler { get; set; }
        public int Id => this.id;
        public RequestType Type => this.type;
    }
}
