
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Web.Mvc;
using <%= fullNamespace %>.Components;
using <%= fullNamespace %>.Data;
using <%= fullNamespace %>.Models;

namespace <%= fullNamespace %>.Controllers
{
    [DnnHandleError]
    public class <%= extensionName %>Controller : DnnController
    {

        public ActionResult Delete(int itemId)
        {
            <%= extensionName %>InfoRepository.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var item = (itemId == -1)
                 ? new <%= extensionName %>Info { ModuleId = ModuleContext.ModuleId }
                 : <%= extensionName %>InfoRepository.Instance.GetItem(itemId, ModuleContext.ModuleId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(<%= extensionName %>Info item)
        {
            if (item.<%= extensionName %>Id == -1)
            {
                item.CreatedByUserId = User.UserID;
                item.CreatedOnDate = DateTime.UtcNow;
                item.LastUpdatedByUserId = User.UserID;
                item.LastUpdatedOnDate = DateTime.UtcNow;

                <%= extensionName %>InfoRepository.Instance.CreateItem(item);
            }
            else
            {
                var existingItem = <%= extensionName %>InfoRepository.Instance.GetItem(item.<%= extensionName %>Id, item.ModuleId);
                existingItem.LastUpdatedByUserId = User.UserID;
                existingItem.LastUpdatedOnDate = DateTime.UtcNow;
                existingItem.Title = item.Title;
                existingItem.Description = item.Description;

                <%= extensionName %>InfoRepository.Instance.UpdateItem(existingItem);
            }

            return RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var items = <%= extensionName %>InfoRepository.Instance.GetItems(ModuleContext.ModuleId);
            return View(items);
        }
    }
}
