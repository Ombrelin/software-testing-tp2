using System;

namespace Ohce
{
    public class RealTimeProvider : ICurrentTimeProvider
    {
        public TimeOnly CurrentTime => TimeOnly.FromDateTime(DateTime.Now);
    }
}