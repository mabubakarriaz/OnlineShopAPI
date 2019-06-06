using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Com.CompanyName.OnlineShop.ComponentLibrary.DataHandler;
using Com.CompanyName.OnlineShop.ComponentLibrary.Entity;

namespace WebAPI.Controllers
{
    public class TourController : ApiController
    {
        public List<Product> Get()
        {
            using (ProductDataHandler handler = new ProductDataHandler())
            {
                return handler.Get().ToList();
            }
        }

        public IHttpActionResult Post()
        {
            throw new HttpResponseException(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent("my error message")
                });
            return Ok("Post");
        }

        public IHttpActionResult Put()
        {
            return Ok("Put");
        }

        public IHttpActionResult Patch()
        {
            return Ok("Patch");
        }
        public IHttpActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}
