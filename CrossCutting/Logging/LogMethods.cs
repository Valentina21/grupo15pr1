using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Shared.Logging
{
    public static class LogMethods
    {
        public static void AddLog(string message, LogsTypes lt)
        {
            int method = int.Parse(ConfigurationSettings.AppSettings["logType"]);
            switch (method)
            {
                case 0:
                    AddEventViewerLog(message, lt);
                    break;
                case 1:
                    AddEventTextFile(message, lt);
                    break;

                default:
                    break;
            }
        }

        private static void AddEventViewerLog(string message, LogsTypes lt)
        {
            EventLogEntryType ltEv = EventLogEntryType.Error;

            if(lt == LogsTypes.Information)
            {
                ltEv = EventLogEntryType.Information;
            }
            else if (lt == LogsTypes.Warning)
            {
                ltEv = EventLogEntryType.Warning;
            }

            string sc = "EmployeeApp";
           if (!EventLog.SourceExists(sc))
            {
                EventLog.CreateEventSource(sc, sc);
            }

            EventLog.WriteEntry(sc, message, ltEv, 100);
        }

        private static void AddEventTextFile(string message, LogsTypes lt)
        {
            string lines = DateTime.Now.ToShortDateString() + " - " + lt.ToString() + " - " + message;

            System.IO.StreamWriter file = new System.IO.StreamWriter(ConfigurationSettings.AppSettings["pathLogFile"]);
            file.WriteLine(lines);

            file.Close();
        }

    }
}
