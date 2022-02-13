using ContactManager.Requests;

namespace ContactManager.Handlers
{
    public class AgentHandler : HandlerBase
    {
        protected override bool CanHandle(IRequest request)
        {
            return !base.requests.Any(r => r.Type == RequestType.VoiceCall)
                && !(base.requests.Any() && request.Type == RequestType.VoiceCall)
                && base.requests.Count < 2;
        }
    }
}
