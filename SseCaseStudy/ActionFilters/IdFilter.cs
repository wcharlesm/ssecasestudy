using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SseCaseStudy.ActionFilters
{
    public class IdFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var id = filterContext.HttpContext.Request.Cookies["ssecasestudycookie"];

            if (id == null)
            {
                id = Guid.NewGuid().ToString();
                var options = new CookieOptions();
                filterContext.HttpContext.Response.Cookies.Append("ssecasestudycookie", id, options);
            }
        }
    }
}
