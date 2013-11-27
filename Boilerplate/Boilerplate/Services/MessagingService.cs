using Boilerplate.Interfaces;

namespace Boilerplate.Services
{
    public class MessagingService : IMessagingService
    {
        public string GetMessage()
        {
            return "Hello world";
        }
    }
}