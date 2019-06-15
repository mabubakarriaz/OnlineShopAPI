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
    [RoutePrefix("api/Carts")]
    public class CartsController : ApiController, IController<Cart>
    {
        private CartDataHandler handler = new CartDataHandler();

        /// <summary>
        /// Get full list of Carts available in db
        /// </summary>
        /// <returns>Enumerable list of cart type</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Cart>))]
        public IHttpActionResult Get()
        {
            using (handler)
            {
                return Ok(handler.Get());
            }
        }

        /// <summary>
        /// Get a single matching cart against provided cart key
        /// </summary>
        /// <param name="id">cart primary key</param>
        /// <returns>an object of cart type</returns>
        [Route("{id:int}"), HttpGet]
        [ResponseType(typeof(Cart))]
        public IHttpActionResult Get([FromUri]int id)
        {
            Cart cart = null;

            using (handler)
            {
                cart = handler.Get(id);
            }

            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);

        }

        /// <summary>
        /// find Carts as per given name
        /// </summary>
        /// <returns>Enumerable list of cart type</returns>
        [Route("{name:alpha}"), HttpGet]
        [ResponseType(typeof(IEnumerable<Cart>))]
        public IHttpActionResult Find([FromUri]string name)
        {
            using (handler)
            {
                return Ok(handler.Find(name));
            }

        }

        /// <summary>
        /// Update an existing cart
        /// </summary>
        /// <param name="id">cart primary key that needs to be changed</param>
        /// <param name="cart">complete cart type with changed data</param>
        /// <returns>Model state is return in case of invalid changes</returns>

        [HttpPut]
        public IHttpActionResult Change([FromUri]int id, [FromBody] Cart cart)
        {
            cart.CartId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Change(cart);
                }
                else
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Add new cart info
        /// </summary>
        /// <param name="cart">Complete cart type with new data</param>
        /// <returns>Model state is return in case of invalid changes</returns>
        [HttpPost]
        public IHttpActionResult Add([FromBody]Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                handler.Add(cart);
            }

            return CreatedAtRoute("DefaultApi", new { id = cart.CartId }, cart);
        }

        /// <summary>
        /// delete the cart from database
        /// </summary>
        /// <param name="id">cart key which needs to be removed</param>
        /// <returns>No content is returned</returns>
        [HttpDelete]
        public IHttpActionResult Remove([FromUri]int id)
        {
            Cart cart = null;

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Remove(cart);
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(cart);
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