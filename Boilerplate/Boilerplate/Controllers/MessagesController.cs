using Boilerplate.Data;
using Boilerplate.Models;
using Boilerplate.Web.CORS;
using Ninject;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Boilerplate.Web.Controllers
{
    [RoutePrefix("api")]
    [CustomCORS]
    public class MessagesController : ApiController
    {
        [Inject]
        public UnitOfWork _uow { get; set; }

        // GET api/Message
        [Route("messages/")]
        public IQueryable<Message> GetMessages()
        {
            return _uow.MessageRepository.Get();
        }

        // GET api/Message/5
        [ResponseType(typeof(Message))]
        [Route("messages/{id:int}")]
        public async Task<IHttpActionResult> GetMessage(int id)
        {
            Message message = await _uow.MessageRepository.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        // PUT api/Message/5
        [Route("messages/{id:int}", Name = "GetMessageById")]
        public async Task<IHttpActionResult> PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != message.Id)
            {
                return BadRequest();
            }

            _uow.MessageRepository.Insert(message);

            try
            {
                await _uow.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_uow.MessageRepository.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.Created);
        }

        // POST api/Message
        [ResponseType(typeof(Message))]
        [Route("messages")]
        public async Task<IHttpActionResult> PostMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.MessageRepository.Insert(message);
            await _uow.SaveChangesAsync();

            return CreatedAtRoute("GetMessageById", new { id = message.Id }, message);
        }

        // DELETE api/Message/5
        [ResponseType(typeof(Message))]
        [Route("messages/{id:int}")]
        public async Task<IHttpActionResult> DeleteMessage(int id)
        {
            Message message = await _uow.MessageRepository.GetByIdAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _uow.MessageRepository.Delete(message);
            await _uow.SaveChangesAsync();

            return Ok(message);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}