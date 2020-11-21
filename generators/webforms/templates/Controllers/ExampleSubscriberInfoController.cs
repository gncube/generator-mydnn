
using System.Collections.Generic;
using System.Linq;
using <%= fullNamespace %>.Entities;

namespace <%= fullNamespace %>.Controllers
{
    public class <%= extensionName %>SubscriberInfoController
    {
        private readonly <%= extensionName %>SubscriberInfoRepository repo = null;

        public <%= extensionName %>SubscriberInfoController() 
        {
            repo = new <%= extensionName %>SubscriberInfoRepository();
        }

        public void CreateItem(<%= extensionName %>SubscriberInfo i)
        {
            repo.CreateItem(i);
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            repo.DeleteItem(itemId, moduleId);
        }

        public void DeleteItem(<%= extensionName %>SubscriberInfo i)
        {
            repo.DeleteItem(i);
        }

        public IEnumerable<<%= extensionName %>SubscriberInfo> GetItems(int moduleId)
        {
            var items = repo.GetItems(moduleId);
            return items;
        }

        public <%= extensionName %>SubscriberInfo GetItem(int itemId, int moduleId)
        {
            var item = repo.GetItem(itemId, moduleId);
            return item;
        }

        public void UpdateItem(<%= extensionName %>SubscriberInfo i)
        {
            repo.UpdateItem(i);
        }

        public <%= extensionName %>SubscriberInfo GetItemByModuleId(int moduleId)
        {
            var items = GetItems(moduleId);

            return items.FirstOrDefault(i => i.ModuleId == moduleId);
        }
    }
}
