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
    /// <summary>
    /// Get Articles
    /// </summary>
    [RoutePrefix("api")]
    [CustomCORS]
    public class ArticlesController : ApiController
    {
        [Inject]
        public UnitOfWork _uow { get; set; }

        // GET api/Article
        /// <summary>
        /// Get a list of Articles
        /// </summary>
        /// <returns>A list of Articles</returns>
        [Route("articles/")]
        public IQueryable<Article> GetArticles()
        {
            return _uow.ArticleRepository.Get();
        }

        // GET api/Article/5
        /// <summary>
        /// Get a article
        /// </summary>
        /// <param name="id">Article id</param>
        /// <returns>A article</returns>
        [ResponseType(typeof(Article))]
        [Route("articles/{id:int}")]
        public async Task<IHttpActionResult> GetArticle(int id)
        {
            Article article = await _uow.ArticleRepository.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        // PUT api/Article/5
        [Route("articles/{id:int}", Name = "GetArticleById")]
        public async Task<IHttpActionResult> PutArticle(int id, Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != article.Id)
            {
                return BadRequest();
            }

            _uow.ArticleRepository.Insert(article);

            try
            {
                await _uow.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_uow.ArticleRepository.GetById(id) == null)
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

        // POST api/Article
        [ResponseType(typeof(Article))]
        [Route("articles")]
        public async Task<IHttpActionResult> PostArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _uow.ArticleRepository.Insert(article);
            await _uow.SaveChangesAsync();

            return CreatedAtRoute("GetArticleById", new { id = article.Id }, article);
        }

        // DELETE api/Article/5
        [ResponseType(typeof(Article))]
        [Route("articles/{id:int}")]
        public async Task<IHttpActionResult> DeleteArticle(int id)
        {
            Article article = await _uow.ArticleRepository.GetByIdAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _uow.ArticleRepository.Delete(article);
            await _uow.SaveChangesAsync();

            return Ok(article);
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