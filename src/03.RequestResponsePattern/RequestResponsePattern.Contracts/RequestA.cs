using System;

namespace RequestResponsePattern.Contracts
{
    public interface RequestA
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
    }

    public interface ResponseA
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
    }
}
