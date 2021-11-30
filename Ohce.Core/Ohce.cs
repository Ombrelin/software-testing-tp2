using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ohce
{

    public class Ohce
    {
        private readonly ICurrentTimeProvider currentTimeProvider;
        private readonly IO io;
        private static string STOP_MESSAGE = "Stop!";
        private static string PALINDROME_MESSAGE = "¡Bonita palabra!";
        private static string GOOD_NIGHT_MESSAGE = "¡Buenas noches";
        private static string GOOD_DAY_MESSAGE = "¡Buenos días";
        private static string GOOD_AFTERNOON_MESSAGE = "¡Buenas tardes";
        
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
                
                if (input == STOP_MESSAGE)
                {
                    await io.OutPutStringAsync($"Adios {name}");
                    await io.HandleExitAsync();
                    break;
                }
                await io.OutPutStringAsync(ReverseWord(input));
                if (IsPalindrome(input))
                {
                    await io.OutPutStringAsync(PALINDROME_MESSAGE);
                }
            }
        }

        public string GetGreeting(string name)
        {
            return this.currentTimeProvider.CurrentTime.Hour switch
            {
                >=0 and <6 or >=20 => $"{GOOD_NIGHT_MESSAGE} {name}!",
                >=6 and <12 => $"{GOOD_DAY_MESSAGE} {name}!",
                >=12 and <20 => $"{GOOD_AFTERNOON_MESSAGE} {name}!",
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

