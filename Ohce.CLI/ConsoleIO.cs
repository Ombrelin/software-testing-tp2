using System.Threading.Tasks;
using System;

namespace Ohce.CLI
{
    public class ConsoleIO : IO
    {
        public async Task OutPutStringAsync(string outPut)
        {
            await Console.Out.WriteLineAsync(outPut);
            await Console.Out.FlushAsync();
        }

        public Task<string> GetInputStringAsync()
        {
            return Console.In.ReadLineAsync();
        }

        public Task HandleExitAsync()
        {
            Environment.Exit(0);
            return Task.CompletedTask;
        }
    }
}