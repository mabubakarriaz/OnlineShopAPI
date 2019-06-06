using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using Com.CompanyName.OnlineShop.ComponentLibrary.Model;

namespace Com.CompanyName.OnlineShop.WebAPI.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController , IController<Product>
    {
        private ProductDataHandler handler = new ProductDataHandler();

        /// <summary>
        /// Get full list of products available in db
        /// </summary>
        /// <returns>Enumerable list of product type</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Product>))]
        public IHttpActionResult Get()
        {
            using (handler)
            {
                return Ok(handler.Get());
            }
        }

        /// <summary>
        /// Get a single matching product against provided product key
        /// </summary>
        /// <param name="id">product primary key</param>
        /// <returns>an object of product type</returns>
        [Route("{id:int}"), HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get([FromUri]int id)
        {
            Product product = null;

            using (handler)
            {
                product = handler.Get(id);
            }

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        /// <summary>
        /// find products as per given name
        /// </summary>
        /// <returns>Enumerable list of product type</returns>
        [Route("{name:alpha}"), HttpGet]
        [ResponseType(typeof(IEnumerable<Product>))]
        public IHttpActionResult Find([FromUri]string name)
        {
            using (handler)
            {
                return Ok(handler.Find(name));
            }

        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        /// <param name="id">product primary key that needs to be changed</param>
        /// <param name="product">complete product type with changed data</param>
        /// <returns>Model state is return in case of invalid changes</returns>

        [HttpPut]
        public IHttpActionResult Change([FromUri]int id, [FromBody] Product product)
        {
            product.ProductId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                if (Exists(id))
                {
                    handler.Change(product);
                }
                else
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Add new product info
        /// </summary>
        /// <param name="product">Complete product type with new data</param>
        /// <returns>Model state is return in case of invalid changes</returns>
        [HttpPost]
        public IHttpActionResult Add([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                handler.Add(product);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// delete the product from database
        /// </summary>
        /// <param name="id">product key which needs to be removed</param>
        /// <returns>No content is returned</returns>
        [HttpDelete]
        public IHttpActionResult Remove([FromUri]int id)
        {
            Product product = null;

            using (handler)
            {
                if (Exists(id))
                {
                    handler.Remove(product);
                }
                else
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                handler.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exists(int id)
        {
            return handler.Get(id).ProductId > 0;
        }
    }
}