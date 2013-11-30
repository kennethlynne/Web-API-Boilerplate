using System.Web.Http;
using Boilerplate.CORS;
using Boilerplate.Data.Interfaces.Services;

namespace Boilerplate.Controllers
{
    [RoutePrefix("api")]
    //[EnableCors(origins: "http://www.example.com", headers: "accept,content-type,origin,x-my-header", methods: "get,post", SupportsCredentials = true)]
    [CustomCORS]
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