using Boilerplate.Data;
using Boilerplate.Data.Interfaces.Services;
using Boilerplate.Models;

namespace Boilerplate.Tests.Mocks
{
    public class MockMessagingService : IMessagingService
    {
        public Message GetMessage()
        {
            return new Message {Text = "Hello world, your mock says hi!"};
        }
    }
}