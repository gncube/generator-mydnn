
using System.Collections.Generic;
using <%= fullNamespace %>.Components;
using <%= fullNamespace %>.Models;
using <%= fullNamespace %>.Tests;

namespace <%= fullNamespace %>.Services
{
    public class ServiceProxy : ServiceProxyBase
    {
        public ServiceProxy(string baseWebSiteUri)
        {
            baseUri = baseWebSiteUri;
            
            if (!baseUri.EndsWith("/"))
            {
                baseUri += "/";
            }

            fullApiUri = System.IO.Path.Combine(baseUri, "DesktopModules/MVC/<%= namespace %>/<%= extensionName %>/API/<%= extensionName %>/");
        }

        public ServiceResponse<string> Create<%= extensionName %>(<%= extensionName %>Info <%= objectName %>)
        {
            var result = new ServiceResponse<string>();

            result = ServiceHelper.PostRequest<ServiceResponse<string>>(fullApiUri + "Create<%= extensionName %>", <%= objectName %>.ObjectToJson());
            
            return result;   
        }

        public ServiceResponse<List<<%= extensionName %>Info>> Get<%= extensionName %>s(int moduleId)
        {
            var result = new ServiceResponse<List<<%= extensionName %>Info>>();

            result = ServiceHelper.GetRequest<ServiceResponse<List<<%= extensionName %>Info>>>(fullApiUri + "Get<%= extensionName %>s?moduleId=" + moduleId);

            return result;
        }

        public ServiceResponse<<%= extensionName %>Info> Get<%= extensionName %>(int itemId)
        {
            var result = new ServiceResponse<<%= extensionName %>Info>();

            result = ServiceHelper.GetRequest<ServiceResponse<<%= extensionName %>Info>>(fullApiUri + "Get<%= extensionName %>?itemId=" + itemId);

            return result;
        }
        
        public ServiceResponse<string> Update<%= extensionName %>(<%= extensionName %>Info <%= objectName %>)
        {
            var result = new ServiceResponse<string>();

            result = ServiceHelper.PostRequest<ServiceResponse<string>>(fullApiUri + "Update<%= extensionName %>", <%= objectName %>.ObjectToJson());

            return result;
        }

        public ServiceResponse<string> Delete<%= extensionName %>(int itemId)
        {
            var result = new ServiceResponse<string>();

            result = ServiceHelper.DeleteRequest<ServiceResponse<string>>(fullApiUri + "Delete<%= extensionName %>?itemId=" + itemId, string.Empty);

            return result;
        }
    }
}
