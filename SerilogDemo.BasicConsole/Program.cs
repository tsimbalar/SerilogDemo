using System.Configuration;
using NLog;
using NLog.Config;
using NLog.Targets;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Formatting.Json;
using Serilog.Formatting.Raw;
using Serilog.Sinks.IOFile;

namespace SerilogDemo.BasicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region NLog
            //// NLog config
            //var consoleTarget = new ColoredConsoleTarget();
            //var nlogConfig = new LoggingConfiguration();
            //nlogConfig.AddTarget("console", consoleTarget);
            //nlogConfig.LoggingRules.Add(new LoggingRule("*", minLevel: LogLevel.Debug, target: consoleTarget));
            //LogManager.Configuration = nlogConfig;
            #endregion

            #region Debugging
            // redirect internal Serilog errors to output so we can diagnose the issues
            //Serilog.Debugging.SelfLog.Out = Console.Error;
            #endregion

            Console.WriteLine("Starting....");

            // configuration Serilog, une fois pour toute ...
            // a destination is a sink 
            var logger = new LoggerConfiguration()
            #region extra config
                //.Enrich.With<VersionEnricher>()
                //.MinimumLevel.Debug() // make debug level visible .. default is information
            #endregion
                            .WriteTo.ColoredConsole()
            #region other sinks
                //.WriteTo.RollingFile("C:\\Temp\\Logs\\app-{Date}.txt", restrictedToMinimumLevel:LogEventLevel.Warning)
                //.WriteTo.Sink(new FileSink("C:\\Temp\\Logs\\dump.txt",  new RawFormatter(), null))
                //            .WriteTo.NLog()
            #endregion
                            .CreateLogger()
                            ;
            #region class logger
            //// Source context to add information about source in logged events (SourceContext)
            //logger = logger.ForContext<Program>();
            #endregion

            logger.Information("Doing stuff with the thing");
            logger.Warning("Be careful, the foo has some baz !");

            logger.Information("with format string {0}, and {1}", "item1", 2);

            logger.Debug("if you are a developper, you may want to know that the answer is 42");
            logger.Verbose("you would usually not see the verbose output, but who knows ?");

            logger.Error(new InvalidOperationException("bummer! that is a nasty exception"),
                "Something went very wrong !");

            logger.Fatal("if you see this message, the app is probably dead...");

            #region Structured data
            // logging structured data
            // =======================

            //// scalar values : string, int ...
            //classLogger.Information("User {User} has logged on as {Login}", "Thibaud Desodt", "tdesodt");

            //classLogger.Warning("Query returned {ResultCount} results and took {QueryDuration} to execute", 2340, TimeSpan.FromMilliseconds(2345));

            //// collections
            //var daysOfTheWeek = new[] {"Monday", "Tuesday", "Wednesday"};
            //classLogger.Information("Days of the week : {DaysOfTheWeek}", daysOfTheWeek.ToList());

            //var birthDates = new Dictionary<string, DateTime>
            //{
            //    {"Thibaud", new DateTime(1984, 4, 2)},
            //    {"Laia", new DateTime(2013, 4, 22)}
            //};
            //classLogger.Warning("Some birthdates ... {BirthDates}", birthDates);

            //// arbitrary objects
            //var encoding = new ASCIIEncoding();
            //classLogger.Information("Encoding : {Encoding}", encoding); // defaults to ToString

            //// destructuring operator !
            //classLogger.Information("Destructured Encoding: {@Encoding}", encoding);

            //// + options to specify how to destructure some specific types when necessary ...

            //// force stringification with "$" operator when wanted (example : IEnumerable)
            //classLogger.Information("Days of the week stringified : {$DaysOfTheWeek}", daysOfTheWeek.ToList());
            #endregion

            Console.WriteLine("Done .... press any key to continue ...");
            Console.ReadLine();
            logger.Information("was asked to stop !");
        }
    }
}
