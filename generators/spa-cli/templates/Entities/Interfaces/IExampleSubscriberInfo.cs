
using System;

namespace <%= fullNamespace %>.Entities
{
    public interface I<%= extensionName %>SubscriberInfo
    {
        int <%= extensionName %>SubscriberId { get; set; }
        int ModuleId { get; set; }
        int UserId { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int? LastUpdatedByUserId { get; set; }
        DateTime? LastUpdatedOnDate { get; set; }
    }
}
