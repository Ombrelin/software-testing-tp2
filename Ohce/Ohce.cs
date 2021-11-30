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
            throw new NotImplementedException();
        }
    }
}

