using ContactManager.Handlers;

namespace ContactManager
{
    public class HandlerValidator : IHandlerValidator
    {
        private Dictionary<Type,int> typesCountDictionary = new Dictionary<Type,int>();

        private readonly Type agentType = typeof(AgentHandler);
        private readonly Type supervisorType = typeof(SupervisorHandler);
        private readonly Type generalManagerType = typeof(GenManagerHandler);

        public void Validate(IHandler handler)
        {
            int agents = 0;
            int supervisors = 0;
            int managers = 0;

            Count(handler);

            if (typesCountDictionary.ContainsKey(agentType))
                agents = typesCountDictionary[agentType];

            if (typesCountDictionary.ContainsKey(supervisorType))
                supervisors = typesCountDictionary[supervisorType];

            if (typesCountDictionary.ContainsKey(generalManagerType))
                managers = typesCountDictionary[generalManagerType];

            if (agents < supervisors)
                throw new ArgumentException("More supervisors than agents.");

            if (managers > 1)
                throw new ArgumentException("More than one manager");
        }

        private void Count(IHandler handler)
        {
            var type = handler.GetType();

            if(typesCountDictionary.ContainsKey(type))
                typesCountDictionary[type]++;
            else
                typesCountDictionary.Add(type, 1);

            if (handler.Next == null)
                return;

            Count(handler.Next);
        }
    }
}
