using Boilerplate.Data.Interfaces;
using Boilerplate.Models;

namespace Boilerplate.Data
{
    public class MessagingService : IMessagingService
    {
        public Message GetMessage()
        {
            return new Message() {Text = "Hello world"};
        }
    }
}