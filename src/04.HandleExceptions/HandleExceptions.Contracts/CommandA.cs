using System;

namespace HandleExceptions.Contracts
{
    public interface CommandA
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
    }
}
