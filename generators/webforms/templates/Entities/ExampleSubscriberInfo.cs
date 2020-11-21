
using System;
using System.Web.Caching;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Users;

namespace <%= fullNamespace %>.Entities
{
    [TableName("<%= objectPrefix %>_<%= extensionName %>Subscribers")]
    [PrimaryKey("<%= extensionName %>SubscriberId", AutoIncrement = true)]
    [Cacheable("<%= extensionName %>SubscriberInfo", CacheItemPriority.Default, 20)]
    [Scope("ModuleId")]
    public class <%= extensionName %>SubscriberInfo : I<%= extensionName %>SubscriberInfo
    {
        #region DB Fields
        public int <%= extensionName %>SubscriberId { get; set; }
        public int ModuleId { get; set; }
        public int UserId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedOnDate { get; set; }
        public int? LastUpdatedByUserId { get; set; }
        public DateTime? LastUpdatedOnDate { get; set; }

        #endregion

        #region NonDB Fields
        [IgnoreColumn]
        public UserInfo CreatedByUser(int portalId)
        {
          if (CreatedByUserId > Null.NullInteger)
          {
            UserInfo user = UserController.GetUserById(portalId, CreatedByUserId);
            return user;
          }
          return null;
        }

        [IgnoreColumn]
        public UserInfo LastUpdatedByUser(int portalId)
        {
          if (LastUpdatedByUserId > Null.NullInteger)
          {
            UserInfo user = UserController.GetUserById(portalId, Convert.ToInt32(LastUpdatedByUserId));
            return user;
          }
          return null;
        }

        #endregion
    }
}
