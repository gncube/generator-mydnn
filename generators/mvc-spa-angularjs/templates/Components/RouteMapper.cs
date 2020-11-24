
using DotNetNuke.Web.Api;

namespace <%= fullNamespace %>.Components
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("MVC/<%= namespace %>/<%= extensionName %>", "default", "{controller}/{action}", new[] { "<%= fullNamespace %>.Services" });
        }
    }
}
