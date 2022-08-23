using CRUD.WebAPI.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CRUD.WebAPI.Enums;
using CRUD.WebAPI.Privilages;

namespace CRUD.WebAPI.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly PermissionEnum.PermissionsEnums _permissionEnum;
        public CustomAuthorizeAttribute(PermissionEnum.PermissionsEnums permissionEnum)
        {
            _permissionEnum = permissionEnum;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var context = filterContext.HttpContext
                .RequestServices
                .GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;

            /*if (filterContext != null)
            {
                var permission = filterContext.HttpContext.User;

                var name = _permissionEnum.ToString();

                var users = context?.Permissions.Where(c => c.PermissionName == name).FirstOrDefault();

                if (string.IsNullOrEmpty(users?.PermissionName?.ToString()))
                {
                    filterContext.Result = new JsonResult(new { message = "Forbidden" }) { StatusCode = StatusCodes.Status403Forbidden };
                }

                return;
            }*/
        }
    }
}
