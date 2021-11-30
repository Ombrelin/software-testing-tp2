using System;

namespace Ohce
{
    public interface ICurrentTimeProvider
    {
        TimeOnly CurrentTime { get; }
    }
}