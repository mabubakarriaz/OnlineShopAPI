using Com.CompanyName.OnlineShop.ComponentLibrary.Data;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Com.CompanyName.OnlineShop.WebAPI.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController, IController<Customer>
    {
        private CustomerDataHandler handler = new CustomerDataHandler();

        /// <summary>
        /// Get full list of customers available in db
        /// </summary>
        /// <returns>Enumerable list of customer type</returns>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Customer>))]
        public IHttpActionResult Get()
        {
            using (handler)
            {
                return Ok(handler.Get());
            }
        }

        /// <summary>
        /// Get a single matching customer against provided customer key
        /// </summary>
        /// <param name="id">customer primary key</param>
        /// <returns>an object of customer type</returns>
        [Route("{id:int}"), HttpGet]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult Get([FromUri]int id)
        {
            Customer customer = null;

            using (handler)
            {
                customer = handler.Get(id);
            }

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);

        }

        /// <summary>
        /// find customers as per given name
        /// </summary>
        /// <returns>Enumerable list of customer type</returns>
        [Route("{name:alpha}"), HttpGet]
        [ResponseType(typeof(IEnumerable<Customer>))]
        public IHttpActionResult Find([FromUri]string name)
        {
            using (handler)
            {
                return Ok(handler.Find(name));
            }

        }

        /// <summary>
        /// Update an existing customer
        /// </summary>
        /// <param name="id">customer primary key that needs to be changed</param>
        /// <param name="customer">complete customer type with changed data</param>
        /// <returns>Model state is return in case of invalid changes</returns>

        [HttpPut]
        public IHttpActionResult Change([FromUri]int id, [FromBody] Customer customer)
        {
            customer.CustomerId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Change(customer);
                }
                else
                {
                    return NotFound();
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Add new customer info
        /// </summary>
        /// <param name="customer">Complete customer type with new data</param>
        /// <returns>Model state is return in case of invalid changes</returns>
        [HttpPost]
        public IHttpActionResult Add([FromBody]Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (handler)
            {
                handler.Add(customer);
            }

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        /// <summary>
        /// delete the customer from database
        /// </summary>
        /// <param name="id">customer key which needs to be removed</param>
        /// <returns>No content is returned</returns>
        [HttpDelete]
        public IHttpActionResult Remove([FromUri]int id)
        {
            Customer customer = null;

            using (handler)
            {
                if (handler.Exists(id))
                {
                    handler.Remove(customer);
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(customer);
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
