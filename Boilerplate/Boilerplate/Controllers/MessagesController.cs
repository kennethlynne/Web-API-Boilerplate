using Boilerplate.Data;
using Boilerplate.Models;
using Boilerplate.Web.CORS;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Boilerplate.Web.Controllers
{
    /// <summary>
    /// Messages
    /// </summary>
    [RoutePrefix("api")]
    //[EnableCors(origins: "http://www.example.com", headers: "accept,content-type,origin,x-my-header", methods: "get,post", SupportsCredentials = true)]
    [CustomCORS]
    public class MessagesController : ApiController
    {
        private readonly UnitOfWork _uow;

        public MessagesController(UnitOfWork UoW)
        {
            _uow = UoW;
        }

        [Route("messages/")]
        public IEnumerable<Message> GetAll()
        {
            return _uow.MessageRepository.Get();
        }

        [Route("messages/{id:int}")]
        public Message GetById(int id)
        {
            var message = _uow.MessageRepository.GetById(id);

            if (message == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                               {
                                   Content = new StringContent(string.Format("No message with ID = {0}", id)),
                                   ReasonPhrase = "Message ID Not Found"
                               };
                throw new HttpResponseException(resp);
            }
            return message;
        }

        [Route("messages")]
        public HttpResponseMessage Post(Message message)
        {
            var response = Request.CreateResponse(HttpStatusCode.Created);

            _uow.MessageRepository.Insert(new Message { Text = DateTime.Now.ToString("yyyyMMddHHmmss") });
            _uow.Save();

            //string uri = Url.Link("MessagesController.GetById", new { id = 1 });
            //response.Headers.Location = new Uri(uri);

            return response;
        }
    }
}