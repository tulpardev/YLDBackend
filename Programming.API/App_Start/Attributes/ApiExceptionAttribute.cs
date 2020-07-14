using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Programming.API.App_Start.Attributes
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
            errorResponse.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = errorResponse;
            base.OnException(actionExecutedContext);
        }
    }
}