using Serilog.Core;
using Serilog.Events;

namespace SerilogDemo.BasicConsole
{
    public class VersionEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("AppVersion", typeof(Program).Assembly.GetName().Version));
        }
    }
}