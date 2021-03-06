using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using GSN.Modules.Task.Components;
using GSN.Modules.Task.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace <%= fullNamespace %>.Controllers
{
  public class HomeController : <%= extensionName %>ModuleControllerBase
  {
    [DnnAuthorize()]
    [HttpGet()]
    public HttpResponseMessage DnnHello()
    {
      try
      {
        string dnnHello = "Hello from DNN!";
        return Request.CreateResponse(HttpStatusCode.OK, dnnHello);
      }
      catch (System.Exception ex)
      {
        //Log exception and reply with Error
        Exceptions.LogException(ex);
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
      }
    }

    [DnnAuthorize()]
    [HttpPost()]
    [ValidateAntiForgeryToken()]
    public HttpResponseMessage DnnHelloPersonalize(DetailsModel data)
    {
      try
      {
        string dnnMessage = "Hello " + data.name + " from DNN!";
        return Request.CreateResponse(HttpStatusCode.OK, dnnMessage);
      }
      catch (System.Exception ex)
      {
        //Log exception and reply with Error
        Exceptions.LogException(ex);
        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
      }
    }
  }
}
