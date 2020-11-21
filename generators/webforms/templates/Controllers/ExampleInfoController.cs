
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Users;
using DotNetNuke.Services.Journal;
using DotNetNuke.Services.Search.Entities;
using DotNetNuke.Services.Social.Messaging;
using DotNetNuke.Services.Social.Notifications;

using <%= fullNamespace %>.Entities;

namespace <%= fullNamespace %>.Controllers
{
    public class <%= extensionName %>InfoController : ModuleSearchBase, IPortable
    {
        private readonly <%= extensionName %>InfoRepository repo = null;

        public <%= extensionName %>InfoController() 
        {
            repo = new <%= extensionName %>InfoRepository();
        }

        public void CreateItem(<%= extensionName %>Info i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(<%= extensionName %>Info i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<<%= extensionName %>Info> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public <%= extensionName %>Info GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(<%= extensionName %>Info i)
        {
            repo.UpdateItem(i);
        }

        public <%= extensionName %>Info GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }

        #region Journal Implementation

        public void Add<%= extensionName %>InfoToJournal(<%= extensionName %>Info i, string journalType, ModuleInfo moduleInfo)
        {
          var objJournalType = JournalController.Instance.GetJournalType(journalType);

          var journalItem = new JournalItem
          {
            PortalId = i.PortalId,
            ProfileId = i.LastUpdatedByUserId,
            UserId = i.LastUpdatedByUserId,
            ContentItemId = i.ContentItemId,
            Title = i.Title
          };

          var data = new ItemData
          {
            Url = "https://geraldncube.co.uk"
          };

          journalItem.ItemData = data;
          journalItem.Summary = HtmlUtils.Shorten(HtmlUtils.Clean(HttpUtility.HtmlDecode(i.Description), false), 250, "...");
          journalItem.Body = i.Description;
          journalItem.JournalTypeId = objJournalType.JournalTypeId;
          journalItem.SecuritySet = "E,";

          JournalController.Instance.SaveJournalItem(journalItem, moduleInfo);
        }

        private void Add<%= extensionName %>InfoNotification(string subject, string body, UserInfo user, UserInfo sender, int portalId)
        {
          var notificationType = NotificationsController.Instance.GetNotificationType(Components.Common.NotificationType.<%= extensionName %>s);
          var notification = new Notification
          {
            NotificationTypeID = notificationType.NotificationTypeId,
            Subject = subject,
            Body = body,
            IncludeDismissAction = true,
            SenderUserID = sender.UserID
          };

          NotificationsController.Instance.SendNotification(notification, portalId, null, new List<UserInfo> { user });
        }

        private void Add<%= extensionName %>InfoMessage(string subject, string body, UserInfo user, UserInfo sender, int portalId)
        {
          var m = new Message { Subject = subject, Body = body };

          MessagingController.Instance.SendMessage(m, null, new List<UserInfo> { user }, null, sender);
        }

        public void SendNotifications(<%= extensionName %>Info t)
        {
          var rc = new <%= extensionName %>SubscriberInfoRepository();
          IEnumerable <<%= extensionName %>SubscriberInfo > subscribers = rc.GetItems(t.ModuleId);
          foreach (var s in subscribers)
          {
            var receiver = UserController.GetUserById(t.PortalId, s.UserId);
            var sender = UserController.GetUserById(t.PortalId, Convert.ToInt32(s.LastUpdatedByUserId));

            Add<%= extensionName %>InfoNotification(t.Title, t.Description, receiver, sender, t.PortalId);
          }
        }

        #endregion

        #region ModuleSearchBase Implementation

        public override IList<SearchDocument> GetModifiedSearchDocuments(ModuleInfo moduleInfo, DateTime beginDateUtc)
        {
          
        }

        #endregion

        #region IPortable Implementation

        public string ExportModule(int ModuleID)
        {
          throw new NotImplementedException();
        }

        public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        {
          throw new NotImplementedException();
        }

        #endregion
    }
}
