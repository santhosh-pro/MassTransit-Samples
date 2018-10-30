using System;

namespace ScheduleMessages.Contracts
{
    public interface CommandA
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
    }
}
