using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerilogDemo.BasicConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting....");

            // configuration Serilog, une fois pour toute ...
            var logConfig = new LoggerConfiguration()
                            //.MinimumLevel.Debug() // make debug level visible .. default is information
                            .WriteTo.ColoredConsole();

            // Source context to add information about source in logged events (SourceContext)
            var classLogger = logConfig.CreateLogger().ForContext<Program>();


            classLogger.Information("Doing stuff with the thing");
            classLogger.Warning("Be careful, the foo has some baz !");

            classLogger.Debug("if you are a developper, you may want to know that the answer is 42");
            classLogger.Verbose("you would usually not see the verbose output, but who knows ?");

            classLogger.Error(new InvalidOperationException("bummer! that is a nasty exception"),
                "Something went very wrong !");

            classLogger.Fatal("if you see this message, the app is probably dead...");

            Console.WriteLine("Done .... press any key to continue ...");
            Console.ReadLine();
            classLogger.Information("was asked to stop !");
        }
    }
}
