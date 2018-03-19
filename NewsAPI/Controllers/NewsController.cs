using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using NewsAPI.Models;

namespace NewsAPI.Controllers
{
    public class NewsController : ApiController
    {
        private NewsAPIContext db = new NewsAPIContext();

        // GET: api/News
        public IQueryable<News> GetNews()
        {
            return db.News.OrderByDescending(x => x.Date).Skip(0).Take(5);
        }

        // GET: api/News
        [Route("api/news/GetNewsRange")]
        public IQueryable<News> GetNewsRange(int skip, int take)
        {
            return db.News.OrderBy(x => x.ID).Skip(skip).Take(take);
        }

        // GET: api/News/5
        [ResponseType(typeof(News))]
        [Route("api/news/GetNewsDetail")]
        public async Task<IHttpActionResult> GetNewsDetail(int id)
        {
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        // PUT: api/News/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNews(int id, News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.ID)
            {
                return BadRequest();
            }

            db.Entry(news).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/News
        [ResponseType(typeof(News))]
        public async Task<IHttpActionResult> PostNews(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.News.Add(news);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = news.ID }, news);
        }

        // DELETE: api/News/5
        [ResponseType(typeof(News))]
        public async Task<IHttpActionResult> DeleteNews(int id)
        {
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            db.News.Remove(news);
            await db.SaveChangesAsync();

            return Ok(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsExists(int id)
        {
            return db.News.Count(e => e.ID == id) > 0;
        }
    }
}