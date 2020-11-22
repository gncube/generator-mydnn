
using System;
using System.Web.Caching;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace <%= fullNamespace %>.Entities
{
    [TableName("<%= objectPrefix %>_<%= extensionName %>s")]
    [PrimaryKey("<%= extensionName %>Id", AutoIncrement = true)]
    [Cacheable("<%= extensionName %>Info", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class <%= extensionName %>Info : I<%= extensionName %>Info
    {
        public int <%= extensionName %>Id { get; set; }
        public int PortalId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ContentItemId { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int LastUpdatedByUserId { get; set; }
        public DateTime LastUpdatedOnDate { get; set; }
    }
}
