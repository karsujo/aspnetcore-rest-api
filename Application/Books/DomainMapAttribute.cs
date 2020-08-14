using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Application.Books
{
    public class DomainMapAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var args = actionContext.ActionArguments;
            var modelState = actionContext.ModelState;
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var args = actionExecutedContext.ActionContext.ActionArguments;
            var modelState = actionExecutedContext.ActionContext.ModelState;
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}
