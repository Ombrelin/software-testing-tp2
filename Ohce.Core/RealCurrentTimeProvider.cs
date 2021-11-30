using System;

namespace Ohce
{
    public class RealCurrentTimeProvider : ICurrentTimeProvider
    {
        public TimeOnly CurrentTime => TimeOnly.FromDateTime(DateTime.Now);
    }
}