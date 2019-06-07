using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Com.CompanyName.OnlineShop.WebAPI.HttpActionResults
{
    public class ErrorContentResult : IHttpActionResult
    {
        public HttpRequestMessage Request;
        public string Content;

        public ErrorContentResult()
        {
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(Content, Encoding.UTF8),
                RequestMessage = Request
            });
        }
    }
}