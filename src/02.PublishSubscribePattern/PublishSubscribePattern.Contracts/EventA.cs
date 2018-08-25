using System;

namespace PublishSubscribePattern.Contracts
{
    public interface EventA
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
    }
}
