

using System;
using System.Threading.Tasks;

namespace Ohce.CLI
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var ohce = new Ohce(new RealCurrentTimeProvider(), new ConsoleIO());
            var name = args[0] ?? throw new ArgumentException("Please provide your name as CLI arg");
            await ohce.Run(name);
        }
    }
}

