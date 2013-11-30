using System.Web.Http;
using Boilerplate.Data.Interfaces.Services;
using Boilerplate.Web.CORS;

namespace Boilerplate.Web.Controllers
{
    /// <summary>
    /// Messages
    /// </summary>
    [RoutePrefix("api")]
    //[EnableCors(origins: "http://www.example.com", headers: "accept,content-type,origin,x-my-header", methods: "get,post", SupportsCredentials = true)]
    [CustomCORS]
    public class MessageController : ApiController
    {
        private readonly IMessagingService _messagingService;

        /// <param name="messagingService"></param>
        public MessageController(IMessagingService messagingService)
        {
            _messagingService = messagingService;
        }


        /// <summary>
        /// Echo a message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Route("messages/{message:minlength(2)}")]
        public string GetMessage(string message)
        {
            return message;
        }

        /// <summary>
        /// Echo message pluss a number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("messages/{id:int}")]
        public string GetMessageById(int id)
        {
            return "Trolol: " + id;
        }
    }
}