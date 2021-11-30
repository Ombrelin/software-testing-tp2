

using System.Threading.Tasks;

namespace Ohce.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var ohce = new Ohce(new RealTimeProvider(), new ConsoleIO());
            await ohce.Run(args[0]);
        }
    }
}

