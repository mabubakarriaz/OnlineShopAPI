using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Com.CompanyName.OnlineShop.WebAPI.Controllers
{
    [RoutePrefix("api/Categories")]
    public class CategoriesController : ApiController, IController<Category>
    {
        private CategoryDataHandler handler = new CategoryDataHandler();

        /// <summary>
        /// Get full list of categories available in db
        /// </summary>
        /// <returns>Enumerable list of category type</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Category>))]
        public IHttpActionResult Get()
        {
            using (handler)
            {
                return Ok(handler.Get());
            }
        }

        /// <summary>
        /// Get a single matching category against provided category key
        /// </summary>
        /// <param name="id">category primary key</param>
        /// <returns>an object of category type</returns>
        [Route("{id:int}"), HttpGet]
        [ResponseType(typeof(Category))]
        public IHttpActionResult Get([FromUri]int id)
        {
            Category category = null;

            using (handler)
            {
                category = handler.Get(id);
            }

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);

        }

        /// <summary>
        /// find categories as per given name
        /// </summary>
        /// <returns>Enumerable list of category type</returns>
        [Route("{name:alpha}"), HttpGet]
        [ResponseType(typeof(IEnumerable<Category>))]
        public IHttpActionResult Find([FromUri]string name)
        {
            using (handler)
            {
                return Ok(handler.Find(name));
            }

        }

        /// <summary>
        /// Update an existing category
        /// </summary>
        /// <param name="id">category primary key that needs to be changed</param>
        /// <param name="category">complete category type with changed data</param>
        /// <returns>Model state is return in case of invalid changes</returns>

        [HttpPut]
        public IHttpActionResult Change([FromUri]int id, [FromBody] Category category)
        {
            category.CategoryId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Change(category);
                }
                else
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Add new category info
        /// </summary>
        /// <param name="category">Complete category type with new data</param>
        /// <returns>Model state is return in case of invalid changes</returns>
        [HttpPost]
        public IHttpActionResult Add([FromBody]Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                handler.Add(category);
            }

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryId }, category);
        }

        /// <summary>
        /// delete the category from database
        /// </summary>
        /// <param name="id">category key which needs to be removed</param>
        /// <returns>No content is returned</returns>
        [HttpDelete]
        public IHttpActionResult Remove([FromUri]int id)
        {
            Category category = null;

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Remove(category);
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                handler.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}