using ContactManager.Requests;

namespace ContactManager.Handlers
{
    public class GenManagerHandler : HandlerBase
    {
        protected static GenManagerHandler? instance;
        protected GenManagerHandler() : base() { }

        public static GenManagerHandler Get()
        {
            if (instance == null)
            {
                instance = new GenManagerHandler();
            }
            return instance;
        }

        protected override bool CanHandle(IRequest request)
        {
            return !base.requests.Any();
        }
    }
}
