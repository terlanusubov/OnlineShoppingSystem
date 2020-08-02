using GagiStoreSystem.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GagiStoreSystem.Attributes
{
    public class Auth : ActionFilterAttribute
    {
        private readonly Claims _claim;
        private bool isAjax;

        public Auth(Claims claim = 0, bool _isAjax = false)
        {
            _claim = claim;
            isAjax = _isAjax;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (_claim == 0)
                    await next();
                else
                {
                    var claimResult = context.HttpContext.User.Claims.Where(c => c.Type == "role" &&  c.Value == Convert.ToInt32(_claim).ToString()).FirstOrDefault();
                    if(claimResult == null)
                    {
                        if (isAjax)
                            context.Result = new JsonResult(new
                            {
                                status = HttpStatusCode.BadRequest
                            });
                        else
                            context.Result = new RedirectToRouteResult(new
                            {
                                controller = "Account",
                                action = "Login"
                            });
                    }
                    else
                    {
                        await next();
                    }
                }
            }
            else
            {
                if (isAjax)
                    context.Result = new JsonResult(new
                    {
                        status = HttpStatusCode.BadRequest
                    });
                else
                    context.Result = new RedirectToRouteResult(new
                    {
                        controller = "Account",
                        action = "Login"
                    });
            }
        }

        
    }
}
