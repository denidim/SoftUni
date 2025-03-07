﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WebShopDemo.Core.Constants;

namespace WebShopDemo.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

        public string UserId
        {
            get 
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

        }

        public string UserFirstName
        {
            get
            {
                string firstName = string.Empty;

                if (User?.Identity?.IsAuthenticated ?? false && User.HasClaim(c => c.Type == ClaimTypeConstants.FirstName))
                {
                    firstName = User.Claims
                        .FirstOrDefault(c=>c.Type == ClaimTypeConstants.FirstName)
                        ?.Value ?? firstName;
                }

                return firstName;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                ViewBag.UserFirstName = UserFirstName;
            }

            base.OnActionExecuted(context);
        }
    }
}
