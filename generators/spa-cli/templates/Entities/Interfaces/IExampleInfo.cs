
using System;

namespace <%= fullNamespace %>.Entities
{
    public interface I<%= extensionName %>Info
    {
        int <%= extensionName %>Id { get; set; }
        int PortalId { get; set; }
        int ModuleId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        int ContentItemId { get; set; }
        int CreatedByUserId { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedOnDate { get; set; }
        int LastUpdatedByUserId { get; set; }
        DateTime LastUpdatedOnDate { get; set; }
    }
}
