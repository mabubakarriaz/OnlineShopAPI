using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.ExceptionHandling;
using System.Web;
using System.Web.Http;
using Com.CompanyName.OnlineShop.WebAPI.HttpActionResults;
using System.Runtime.Serialization;
using System.Xml;
using System.Text;

namespace Com.CompanyName.OnlineShop.WebAPI.Exceptions
{
    public class UnhandledExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {

#if DEBUG
            base.Handle(context);
#else
            context.Result = new ErrorContentResult()
            {
                Request = context.ExceptionContext.Request,
                Content = "Oops! Sorry! Something went wrong."
            };
#endif

        }
    }
}