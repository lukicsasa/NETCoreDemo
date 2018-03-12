using Demo.API.Controllers;
using Demo.API.Models;
using Demo.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.API.Helpers
{
    public class TokenAuthorizeAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers.FirstOrDefault(a => a.Key == "Authorization");
            if (authorizationHeader.Key == null)
                throw new AuthenticationException("No authorization header present!");

            string tokenString = authorizationHeader.Value.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(tokenString))
                throw new AuthenticationException("Authorization header can not be empty!");

            UserJwtModel user;
            try
            {
                user = SecurityHelper.Decode<UserJwtModel>(tokenString);
            }
            catch 
            {
                throw new AuthenticationException("Invalid token!");
            }

            if (user.ExpirationDate < DateTime.UtcNow)
                throw new AuthenticationException("Token expired! Please, log in again!");

            if (Roles != null && !Roles.Split(',').ToList().Contains(user.Role.Name))
                throw new AuthenticationException("You do not have permissions to access this resource!");

            var controller = context.Controller as BaseController;
            if (controller != null) controller.CurrentUser = user;

            base.OnActionExecuting(context);
        }
    }
}
