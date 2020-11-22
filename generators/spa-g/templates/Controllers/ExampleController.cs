
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using System.Web.Mvc;
using DotNetNuke.Framework;
using <%= fullNamespace %>.Components;
using <%= fullNamespace %>.Data;

namespace <%= fullNamespace %>.Controllers
{
    [DnnHandleError]
    public class <%= extensionName %>Controller : <%= extensionName %>ModuleControllerBase
    {
        public ActionResult Index()
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);
            ServicesFramework.Instance.RequestAjaxAntiForgerySupport();

            var items = <%= extensionName %>InfoRepository.Instance.GetItems(ModuleContext.ModuleId);

            ViewBag.PortalId = ModuleContext.PortalId;
            ViewBag.ModuleId = ModuleContext.ModuleId;
            ViewBag.ModulePath = $"/DesktopModules/MVC/<%= namespace %>/<%= extensionName %>/";

            return View(items);
        }
    }
}
