using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using PlaneTicketReservationSystem.Business.Models;
using System;
using Microsoft.AspNetCore.Mvc;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
