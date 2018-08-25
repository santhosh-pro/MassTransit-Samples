using System;

namespace SendPattern.Contracts
{
    public interface CommandA
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
    }
}
