using ContactManager.Handlers;

namespace ContactManager
{
    public interface IHandlerValidator
    {
        void Validate(IHandler handler);
    }
}