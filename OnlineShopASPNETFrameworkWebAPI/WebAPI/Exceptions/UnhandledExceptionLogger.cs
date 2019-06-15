using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace Com.CompanyName.OnlineShop.WebAPI.Exceptions
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {

            string errorMessage = $"Exception-Message: {context.Exception.Message}\n" +
                $"Inner-Exception-Message: {context.Exception.InnerException.Message}\n" +
                $"Context: {context.Request.ToString()}\n";

            // write to event logs
            EventHelper.AddEvent(errorMessage, EventLogEntryType.Error, 1, 1);

            //write to debug
            Debug.WriteLine($"Error: {errorMessage}");
        }
    }
}