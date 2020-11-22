

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Caching;

namespace <%= fullNamespace %>.Models
{
    [TableName("<%= objectPrefix %>_<%= extensionName %>")]
    //setup the primary key for table
    [PrimaryKey("<%= extensionName %>Id", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("<%= extensionName %>Info", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class <%= extensionName %>Info : I<%= extensionName %>Info
    {
        public <%= extensionName %>Info()
        {
            <%= extensionName %>Id = -1;
        }

        public int <%= extensionName %>Id { get; set; }

        public int ModuleId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int ContentItemId { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedOnDate { get; set; }

        public int LastUpdatedByUserId { get; set; }

        public DateTime LastUpdatedOnDate { get; set; }

        #region NonDB Fields

        [IgnoreColumn]
        public UserInfo CreatedByUser()
        {
          if (CreatedByUserId > Null.NullInteger)
          {
            UserInfo user = UserController.GetUserById(PortalSettings.Current.PortalId, CreatedByUserId);
            return user;
          }
          return null;
        }

        [IgnoreColumn]
        public UserInfo LastUpdatedByUser()
        {
          if (LastUpdatedByUserId > Null.NullInteger)
          {
            UserInfo user = UserController.GetUserById(PortalSettings.Current.PortalId, LastUpdatedByUserId);
            return user;
          }
          return null;
        }

        #endregion
    }
}
