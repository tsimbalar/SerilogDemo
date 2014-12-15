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
            // configuration Serilog, une fois pour toute ...
            var logger = new LoggerConfiguration()
                            .WriteTo.ColoredConsole()
                            .CreateLogger();

            Console.WriteLine("Starting....");

            logger.Information("Doing stuff with the thing");
            logger.Warning("Be careful, the foo has some baz !");

            logger.Debug("if you are a developper, you may want to know that the answer is 42");
            logger.Verbose("you would usually not see the verbose output, but who knows ?");

            logger.Error(new InvalidOperationException("bummer! that is a nasty exception"),
                "Something went very wrong !");

            logger.Fatal("if you see this message, the app is probably dead...");

            Console.WriteLine("Done .... press any key to continue ...");
            Console.ReadLine();
            logger.Information("was asked to stop !");
        }
    }
}
