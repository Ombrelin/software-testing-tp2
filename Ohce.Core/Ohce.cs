using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ohce
{

    public class Ohce
    {
        private readonly ICurrentTimeProvider currentTimeProvider;
        private readonly IO io;

        public Ohce(ICurrentTimeProvider currentTimeProvider, IO io)
        {
            this.currentTimeProvider = currentTimeProvider;
            this.io = io;
        }

        public async Task Run(string name)
        {
            await io.OutPutStringAsync(GetGreeting(name));

            while (true)
            {
                string input = await io.GetInputStringAsync();
                if (input == "Stop!")
                {
                    await io.HandleExitAsync();
                    break;
                }
                await io.OutPutStringAsync(ReverseWord(input));
                if (IsPalindrome(input))
                {
                    await io.OutPutStringAsync("¡Bonita palabra!");
                }
            }
        }

        public string GetGreeting(string name)
        {
            return this.currentTimeProvider.CurrentTime.Hour switch
            {
                >=0 and <6 or >=20 => $"¡Buenas noches {name}!",
                >=6 and <12 => $"¡Buenos días {name}!",
                >=12 and <20 => $"¡Buenas tardes {name}!",
                _ => throw new ArgumentException($"Unsupported hour : {this.currentTimeProvider.CurrentTime.Hour}")
            };
        }

        public bool IsPalindrome(string word)
        {
            return word.ToLower() == ReverseWord(word).ToLower();
        }

        public string ReverseWord(string word)
        {
            return new string(word.Reverse().ToArray());
        }
    }
}

