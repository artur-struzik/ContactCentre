using ContactManager.Requests;

namespace ContactManager.Handlers
{
    public abstract class HandlerBase : IHandler
    {
        public IHandler? Next { get; private set; }

        public IHandler SetNext(IHandler next)
        {
            Next = next;
            return Next;
        }

        protected List<IRequest> requests;

        public HandlerBase()
        {
            requests = new List<IRequest>();
        }

        public virtual bool Handle(IRequest request)
        {
            if (!CanHandle(request))
                return Next?.Handle(request) ?? false;
            else
                requests.Add(request);

            return true;
        }

        public void EndRequest(int requestId) 
        {
            IRequest? reqToRemove = requests.SingleOrDefault(r => r.Id == requestId);
            if(reqToRemove != null)
            {
                requests.Remove(reqToRemove);
                return;
            }

            if (Next == null)
                throw new ArgumentException($"No request with id:{requestId}");

            Next.EndRequest(requestId);
        }

        protected abstract bool CanHandle(IRequest request);
    }
}
