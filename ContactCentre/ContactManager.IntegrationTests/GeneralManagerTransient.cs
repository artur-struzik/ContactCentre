using ContactManager.Handlers;

namespace ContactManager.IntegrationTests
{
    public class GeneralManagerTransient : GenManagerHandler
    {
        public GeneralManagerTransient() : base() 
        {
            instance = this;
        }
    }
}
