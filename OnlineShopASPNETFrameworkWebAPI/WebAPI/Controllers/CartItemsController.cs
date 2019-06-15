using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Com.CompanyName.OnlineShop.WebAPI.Controllers
{
    [RoutePrefix("api/CartItems")]
    public class CartItemsController : ApiController, IController<CartItem>
    {
        private CartItemDataHandler handler = new CartItemDataHandler();

        /// <summary>
        /// Get full list of CartItems available in db
        /// </summary>
        /// <returns>Enumerable list of cart item type</returns>
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
        /// Get a single matching cart item against provided cart item key
        /// </summary>
        /// <param name="id">cart item primary key</param>
        /// <returns>an object of cart item type</returns>
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
        /// <returns>Enumerable list of cart item type</returns>
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
        /// Update an existing cart item
        /// </summary>
        /// <param name="id">cart item primary key that needs to be changed</param>
        /// <param name="cartItem">complete cart item type with changed data</param>
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
        /// Add new cart item info
        /// </summary>
        /// <param name="cartItem">Complete cart item type with new data</param>
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
        /// delete the cart item from database
        /// </summary>
        /// <param name="id">cart item key which needs to be removed</param>
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