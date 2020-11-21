
using System;

namespace <%= fullNamespace %>.Models
{
    public interface I<%= extensionName %>Info
    {
        int <%= extensionName %>Id { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int ContentItemId { get; set; }
        int CreatedByUserId { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastUpdatedByUserId { get; set; }
        DateTime LastUpdatedOnDate { get; set; }
    }
}
