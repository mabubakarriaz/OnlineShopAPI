using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Com.CompanyName.OnlineShop.WebAPI.Exceptions
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            string errorMessage = $"Message: {context.Exception.Message}, Inner-Exception: {context.Exception.InnerException}";

            // write to event logs
            EventHelper.AddEvent(errorMessage, EventLogEntryType.Error, 1, 1);

            //write to debug
            Debug.WriteLine($"Error: {errorMessage}");
        }
    }
}