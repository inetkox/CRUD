using CRUD.WebAPI.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CRUD.WebAPI.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string CurrentPermissionName;
        public CustomAuthorizeAttribute(string currentPermissionName)
        {
            CurrentPermissionName = currentPermissionName;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var context = filterContext.HttpContext
                .RequestServices
                .GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

            if (filterContext != null)
            {
                var users = context?.Permissions.Where(c => c.PermissionName == CurrentPermissionName).FirstOrDefault();

                if (string.IsNullOrEmpty(users?.PermissionName?.ToString()))
                {
                    filterContext.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
                }

                return;
            }
        }
    }
}
