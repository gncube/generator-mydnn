
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using <%= fullNamespace %>.Data;
using <%= fullNamespace %>.Models;

namespace <%= fullNamespace %>.Data
{
    public interface I<%= extensionName %>InfoRepository
    {
        void CreateItem(<%= extensionName %>Info t);
        void DeleteItem(int itemId, int moduleId);
        void DeleteItem(<%= extensionName %>Info t);
        IEnumerable<<%= extensionName %>Info> GetItems(int moduleId);
        <%= extensionName %>Info GetItem(int itemId, int moduleId);
        void UpdateItem(<%= extensionName %>Info t);
    }

    public class <%= extensionName %>InfoRepository : ServiceLocator<I<%= extensionName %>InfoRepository, <%= extensionName %>InfoRepository>, I<%= extensionName %>InfoRepository
    {
        public void CreateItem(<%= extensionName %>Info t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>Info>();
                rep.Insert(t);
            }
        }

        public void DeleteItem(int itemId, int moduleId)
        {
            var t = GetItem(itemId, moduleId);
            DeleteItem(t);
        }

        public void DeleteItem(<%= extensionName %>Info t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>Info>();
                rep.Delete(t);
            }
        }

        public IEnumerable<<%= extensionName %>Info> GetItems(int moduleId)
        {
            IEnumerable<<%= extensionName %>Info> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>Info>();
                t = rep.Get(moduleId);
            }
            return t;
        }

        public <%= extensionName %>Info GetItem(int itemId, int moduleId)
        {
            <%= extensionName %>Info t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>Info>();
                t = rep.GetById(itemId, moduleId);
            }
            return t;
        }

        public void UpdateItem(<%= extensionName %>Info t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<<%= extensionName %>Info>();
                rep.Update(t);
            }
        }

        protected override System.Func<I<%= extensionName %>InfoRepository> GetFactory()
        {
            return () => new <%= extensionName %>InfoRepository();
        }
    }
}
