
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DotNetNuke.Security;
using DotNetNuke.Security.Permissions;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using <%= fullNamespace %>.Components;
using <%= fullNamespace %>.Models;

namespace <%= fullNamespace %>.Services
{
    /// <summary>
    /// This is a partial class that spans multiple class files, in order to keep the code manageable. Each method is necessary to support the front end SPA implementation.
    /// </summary>
    /// <remarks>
    /// The SupportModules attribute will require that all API calls set and include module headers, event GET requests. Even Fiddler will return 401 Unauthorized errors.
    /// </remarks>
    [SupportedModules("<%= extensionName %>")]
    public partial class <%= extensionName %>Controller : ServiceBase
    {
  /// <summary>
  /// Get an event
  /// </summary>
  /// <returns></returns>
  /// <remarks>
  /// GET: http://dnndev.me/DesktopModules/MVC/<%= namespace %>/<%= extensionName %>/API/<%= extensionName %>/Get<%= extensionName %>s
  /// </remarks>
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [HttpGet]
        public HttpResponseMessage Get<%= extensionName %>s()
        {
            try
            {
                var <%= objectName %>s = <%= extensionName %>DataAccess.GetItems(ActiveModule.ModuleID);
                var response = new ServiceResponse<List<<%= extensionName %>Info>> { Content = <%= objectName %>s.ToList() };

                if (<%= objectName %>s == null || !<%= objectName %>s.Any())
                {
                    ServiceResponseHelper<List<<%= extensionName %>Info>>.AddNoneFoundError("<%= extensionName %>Info", ref response);
                }

                return Request.CreateResponse(HttpStatusCode.OK, response.ObjectToJson());
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ERROR_MESSAGE);
            }
        }

  /// <summary>
  /// Get an event
  /// </summary>
  /// <returns></returns>
  /// <remarks>
  /// GET: http://dnndev.me/DesktopModules/<%= namespace %>/<%= extensionName %>/MVC/API/<%= extensionName %>/Get<%= extensionName %>
  /// </remarks>
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.View)]
        [HttpGet]
        public HttpResponseMessage Get<%= extensionName %>(int <%= objectName %>Id)
        {
            try
            {
                var <%= objectName %> = <%= extensionName %>DataAccess.GetItem(<%= objectName %>Id, ActiveModule.ModuleID);
                var response = new ServiceResponse<<%= extensionName %>Info> { Content = <%= objectName %> };

                if (<%= objectName %> == null)
                {
                    ServiceResponseHelper<<%= extensionName %>Info>.AddNoneFoundError("<%= extensionName %>Info", ref response);
                }

                return Request.CreateResponse(HttpStatusCode.OK, response.ObjectToJson());
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ERROR_MESSAGE);
            }
        }

  /// <summary>
  /// Delete an event
  /// </summary>
  /// <returns></returns>
  /// <remarks>
  /// DELETE: http://dnndev.me/DesktopModules/<%= namespace %>/<%= extensionName %>/MVC/API/<%= extensionName %>/Delete<%= extensionName %>
  /// </remarks>
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
        [ValidateAntiForgeryToken]
        [HttpDelete]
        public HttpResponseMessage Delete<%= extensionName %>(int <%= objectName %>Id)
        {
            try
            {
                <%= extensionName %>DataAccess.DeleteItem(<%= objectName %>Id, ActiveModule.ModuleID);
                var response = new ServiceResponse<string> { Content = SUCCESS_MESSAGE };

                return Request.CreateResponse(HttpStatusCode.OK, response.ObjectToJson());
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ERROR_MESSAGE);
            }
        }

  /// <summary>
  /// Create an event
  /// </summary>
  /// <returns></returns>
  /// <remarks>
  /// POST: http://dnndev.me/DesktopModules/MVC/<%= namespace %>/<%= extensionName %>/API/<%= extensionName %>/Ceate<%= extensionName %>
  /// </remarks>
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public HttpResponseMessage Create<%= extensionName %>(<%= extensionName %>Info new<%= extensionName %>)
        {
            try
            {
                new<%= extensionName %>.CreatedOnDate = DateTime.Now;
                new<%= extensionName %>.CreatedByUserId = UserInfo.UserID;
                new<%= extensionName %>.LastUpdatedOnDate = DateTime.Now;
                new<%= extensionName %>.LastUpdatedByUserId = UserInfo.UserID;
                new<%= extensionName %>.ModuleId = ActiveModule.ModuleID;

                var security = new PortalSecurity();

                new<%= extensionName %>.Title = security.InputFilter(new<%= extensionName %>.Title.Trim(), PortalSecurity.FilterFlag.NoMarkup);
                new<%= extensionName %>.Description = security.InputFilter(new<%= extensionName %>.Description.Trim(), PortalSecurity.FilterFlag.NoMarkup);

                <%= extensionName %>DataAccess.CreateItem(new<%= extensionName %>);

                var response = new ServiceResponse<string> { Content = Globals.RESPONSE_SUCCESS };

                return Request.CreateResponse(HttpStatusCode.OK, response.ObjectToJson());
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ERROR_MESSAGE);
            }
        }

  /// <summary>
  /// Update an event
  /// </summary>
  /// <returns></returns>
  /// <remarks>
  /// POST: http://dnndev.me/DesktopModules/MVC/<%= namespace %>/<%= extensionName %>/API/<%= extensionName %>/Update<%= extensionName %>
  /// </remarks>
  [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public HttpResponseMessage Update<%= extensionName %>(<%= extensionName %>Info <%= objectName %>)
        {
            try
            {
                var original<%= extensionName %> = <%= extensionName %>DataAccess.GetItem(<%= objectName %>.<%= extensionName %>Id, <%= objectName %>.ModuleId);
                var updatesToProcess = <%= extensionName %>HasUpdates(ref original<%= extensionName %>, ref <%= objectName %>);

                if (updatesToProcess)
                {
                    original<%= extensionName %>.LastUpdatedOnDate = DateTime.Now;
                    original<%= extensionName %>.LastUpdatedByUserId = UserInfo.UserID;

                    var security = new PortalSecurity();

                    original<%= extensionName %>.Title = security.InputFilter(original<%= extensionName %>.Title.Trim(), PortalSecurity.FilterFlag.NoMarkup);
                    original<%= extensionName %>.Description = security.InputFilter(original<%= extensionName %>.Description.Trim(), PortalSecurity.FilterFlag.NoMarkup);

                    <%= extensionName %>DataAccess.UpdateItem(original<%= extensionName %>);
                }

                var saved<%= extensionName %> = <%= extensionName %>DataAccess.GetItem(original<%= extensionName %>.<%= extensionName %>Id, original<%= extensionName %>.ModuleId);

                var response = new ServiceResponse<<%= extensionName %>Info> { Content = saved<%= extensionName %> };

                return Request.CreateResponse(HttpStatusCode.OK, response.ObjectToJson());
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ERROR_MESSAGE);
            }
        }

  /// <summary>
  /// Use to determine if the user has edit permissions
  /// </summary>
  /// <returns></returns>
  /// <remarks>
  /// GET: http://dnndev.me/DesktopModules/MVC/<%= namespace %>/<%= extensionName %>/API/<%= extensionName %>/UserCanEdit<%= extensionName %>
  /// </remarks>
  [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage UserCanEdit<%= extensionName %>()
        {
            ServiceResponse<string> response = null;

            if (UserInfo.IsSuperUser || UserInfo.IsInRole(PortalSettings.AdministratorRoleName) || ModulePermissionController.HasModulePermission(ActiveModule.ModulePermissions, "Edit"))
            {
                response = new ServiceResponse<string>() { Content = Globals.RESPONSE_SUCCESS };
            }
            else
            {
                response = new ServiceResponse<string>() { Content = Globals.RESPONSE_FAILURE };
            }

            return Request.CreateResponse(HttpStatusCode.OK, response.ObjectToJson());
        }

        #region Private Helper Methods

        private bool <%= extensionName %>HasUpdates(ref <%= extensionName %>Info original<%= extensionName %>, ref <%= extensionName %>Info new<%= extensionName %>)
        {
            var updatesToProcess = false;

            if (!string.Equals(new<%= extensionName %>.Title, original<%= extensionName %>.Title))
            {
                original<%= extensionName %>.Title = new<%= extensionName %>.Title;
                updatesToProcess = true;
            }

            if (!string.Equals(new<%= extensionName %>.Description, original<%= extensionName %>.Description))
            {
                original<%= extensionName %>.Description = new<%= extensionName %>.Description;
                updatesToProcess = true;
            }

            if (new<%= extensionName %>.ModuleId != original<%= extensionName %>.ModuleId)
            {
                original<%= extensionName %>.ModuleId = new<%= extensionName %>.ModuleId;
                updatesToProcess = true;
            }

            return updatesToProcess;
        }

        #endregion
    }
}
