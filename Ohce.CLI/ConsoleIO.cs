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

        public async Task<string> GetInputStringAsync()
        {
            string? inputStringAsync = await Console.In.ReadLineAsync();
            return inputStringAsync ?? throw new ArgumentException("Please input a value");
        }

        public Task HandleExitAsync()
        {
            Environment.Exit(0);
            return Task.CompletedTask;
        }
    }
}