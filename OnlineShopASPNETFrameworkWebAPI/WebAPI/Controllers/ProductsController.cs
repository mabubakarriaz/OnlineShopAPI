using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using Com.CompanyName.OnlineShop.ComponentLibrary.Model;

namespace Com.CompanyName.OnlineShop.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private ProductDataHandler handler = new ProductDataHandler();

        /// <summary>
        /// Get full list of products available in db
        /// </summary>
        /// <returns>Queryable list of product type</returns>
        [HttpGet]
        public IQueryable<Product> Get()
        {
            using (handler)
            {
                return (IQueryable<Product>)handler.Get();
            }

        }

        /// <summary>
        /// Get a single mataching product against provided product key
        /// </summary>
        /// <param name="id">product primary key</param>
        /// <returns>an object of product</returns>
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
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
        /// change an existing product
        /// </summary>
        /// <param name="id">product primary key that needs to be changed</param>
        /// <param name="product">complete product type with changed data</param>
        /// <returns>provide product type with  model state is return in case of invalid changes</returns>
        [HttpPut]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Change(int id, Product product)
        {
            product.ProductId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                if (ProductExists(id))
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
        /// Add new product type
        /// </summary>
        /// <param name="product">Complete product type with new data</param>
        /// <returns>responds with newly added product</returns>
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                handler.Add(product);
                return Ok(handler.Get(product.ProductId));
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Remove(int id)
        {
            Product product = null;

            using (handler)
            {
                product = handler.Get(id);

                if (product == null)
                {
                    return NotFound();
                }

                handler.Remove(product);
            }

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                handler.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return handler.Get(id).ProductId > 0;
        }
    }
}