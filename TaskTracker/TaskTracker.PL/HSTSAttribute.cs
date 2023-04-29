using System.Web.Http.Filters;

namespace TaskTracker.PL
{
    public class HSTSAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
