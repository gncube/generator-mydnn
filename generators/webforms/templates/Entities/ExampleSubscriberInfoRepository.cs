
using System.Collections.Generic;
using DotNetNuke.Data;

namespace <%= fullNamespace %>.Entities
{
    public class <%= extensionName %>SubscriberInfoRepository
    {
        public void CreateItem(<%= extensionName %>SubscriberInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>SubscriberInfo>();
                rep.Insert(i);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var i = GetItem(itemId, moduleId);
            DeleteItem(i);
        }

        public void DeleteItem(<%= extensionName %>SubscriberInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>SubscriberInfo>();
                rep.Delete(i);
            }
        }

        public IEnumerable<<%= extensionName %>SubscriberInfo> GetItems(int moduleId)
        {
            IEnumerable<<%= extensionName %>SubscriberInfo> i;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>SubscriberInfo>();
                i = rep.Get(moduleId);
            }
            return i;
        }

        public <%= extensionName %>SubscriberInfo GetItem(int itemId, int moduleId)
        {
            <%= extensionName %>SubscriberInfo i = null;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>SubscriberInfo>();
                i = rep.GetById(itemId, moduleId);
            }
            return i;
        }

        public void UpdateItem(<%= extensionName %>SubscriberInfo i)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>SubscriberInfo>();
                rep.Update(i);
            }
        }
    }
}
