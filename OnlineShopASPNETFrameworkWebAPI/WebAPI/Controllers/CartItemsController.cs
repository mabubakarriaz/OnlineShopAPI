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
using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using Com.CompanyName.OnlineShop.ComponentLibrary.Model;

namespace Com.CompanyName.OnlineShop.WebAPI.Controllers
{
    [RoutePrefix("api/CartItems")]
    public class CartItemsController : ApiController, IController<CartItem>
    {
        private CartItemDataHandler handler = new CartItemDataHandler();

        /// <summary>
        /// Get full list of CartItems available in db
        /// </summary>
        /// <returns>Enumerable list of category type</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CartItem>))]
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
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult Get([FromUri]int id)
        {
            CartItem cartItem = null;

            using (handler)
            {
                cartItem = handler.Get(id);
            }

            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(cartItem);

        }

        /// <summary>
        /// find CartItems as per given name
        /// </summary>
        /// <returns>Enumerable list of category type</returns>
        [Route("{name:alpha}"), HttpGet]
        [ResponseType(typeof(IEnumerable<CartItem>))]
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
        /// <param name="cartItem">complete category type with changed data</param>
        /// <returns>Model state is return in case of invalid changes</returns>

        [HttpPut]
        public IHttpActionResult Change([FromUri]int id, [FromBody] CartItem cartItem)
        {
            cartItem.CartItemId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Change(cartItem);
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
        /// <param name="cartItem">Complete category type with new data</param>
        /// <returns>Model state is return in case of invalid changes</returns>
        [HttpPost]
        public IHttpActionResult Add([FromBody]CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                handler.Add(cartItem);
            }

            return CreatedAtRoute("DefaultApi", new { id = cartItem.CartItemId }, cartItem);
        }

        /// <summary>
        /// delete the category from database
        /// </summary>
        /// <param name="id">category key which needs to be removed</param>
        /// <returns>No content is returned</returns>
        [HttpDelete]
        public IHttpActionResult Remove([FromUri]int id)
        {
            CartItem cartItem = null;

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Remove(cartItem);
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(cartItem);
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