using System;

namespace Ohce
{

    public class Ohce
    {
        private readonly ICurrentTimeProvider currentTimeProvider;

        public Ohce(ICurrentTimeProvider currentTimeProvider)
        {
            this.currentTimeProvider = currentTimeProvider;
        }

        public string GetGreeting(string name)
        {
            if (this.currentTimeProvider.CurrentTime.Hour >= 20)
            {
                return $"¡Buenas noches {name}!";
            }
            else
            {
                return $"¡Buenos días {name}!";
            }
        }
    }
}

