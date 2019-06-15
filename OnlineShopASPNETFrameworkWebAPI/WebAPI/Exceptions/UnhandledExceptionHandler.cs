using Com.CompanyName.OnlineShop.WebAPI.HttpActionResults;
using System.Web.Http.ExceptionHandling;

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