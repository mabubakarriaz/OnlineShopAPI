using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Com.CompanyName.OnlineShop.WebAPI.Exceptions
{
    public class DbUpdateExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (!(context.Exception is DbUpdateException)) return;

            var sqlException = context.Exception?
                .InnerException?.InnerException as SqlException;

            //foreign key conflict
            if (sqlException?.Number == 2627)
                context.Response = new HttpResponseMessage(HttpStatusCode.Conflict);

            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}