using ContactManager.Handlers;

namespace ContactManager.UnitTests
{
    public class GeneralManagerTransient : GenManagerHandler
    {
        public GeneralManagerTransient() : base()
        {
            instance = this;
        }
    }
}
