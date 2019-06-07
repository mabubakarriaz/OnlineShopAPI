using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Com.CompanyName.OnlineShop.WebAPI.Exceptions
{
    public static class EventHelper
    {
        public static void AddEvent(string message,EventLogEntryType entryType,int eventId,short eventCategory) {

            string source = "OnlineShop";  ///column name "source"
            string logName = "Web API"; /// Windows Log > "Application" || Applications and services log > "logName"

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, logName);
            }

            EventLog eventLog = new EventLog();
            eventLog.Source = source;
            eventLog.Log = logName;
            eventLog.WriteEntry(message, entryType, eventId, eventCategory);
        }

    }
}