
using DotNetNuke.Web.Api;
using <%= fullNamespace %>.Data;
using <%= fullNamespace %>.Models;

namespace <%= fullNamespace %>.Services
{
    public class ServiceBase : DnnApiController
    {
        protected const string SUCCESS_MESSAGE = "SUCCESS";
        protected const string ERROR_MESSAGE = "An error occurred. Please check the event log or contact your website administrator for more information";

        protected <%= extensionName %>InfoRepository <%= extensionName %>DataAccess { get; set; }

        public ServiceBase()
        {
            <%= extensionName %>DataAccess = new <%= extensionName %>InfoRepository(); 
        }
    }
}
