using System.Web.Http;
using Boilerplate.Interfaces;

namespace Boilerplate.Controllers
{
    [RoutePrefix("api")]
    public class MessageController : ApiController
    {
        private readonly IMessagingService _messagingService;

        public MessageController(IMessagingService messagingService)
        {
            _messagingService = messagingService;
        }

        [Route("messages/{message:minlength(2)}")]
        public string GetMessage(string message)
        {
            return message;
        }

        [Route("messages/{id:int}")]
        public string GetMessageById(int id)
        {
            return "Trolol: " + id;
        }
    }
}