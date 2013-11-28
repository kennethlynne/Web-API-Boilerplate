using Boilerplate.Data.Interfaces.Services;
using Boilerplate.Models;

namespace Boilerplate.Data
{
    public class MessagingService : IMessagingService
    {
        public Message GetMessage()
        {
            return new Message() { Text = "Hello world" };
        }
    }
}