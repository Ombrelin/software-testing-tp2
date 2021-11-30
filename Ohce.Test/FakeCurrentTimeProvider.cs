using System;

namespace Ohce.Test
{
    public class FakeCurrentTimeProvider : ICurrentTimeProvider
    {
        public FakeCurrentTimeProvider(TimeOnly currentTime)
        {
            CurrentTime = currentTime;
        }

        public TimeOnly CurrentTime { get; }
    }
}