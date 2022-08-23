using CRUD.WebAPI.Privilages;

namespace CRUD.WebAPI.Enums
{
    public static class EnumConversion
    {
        public static IEnumerable<TModel> GetElementsFromEnum<TModel, TEnum>() where TModel : IPermission<TModel, TEnum>, new()
        {
            var permissionsEnumsList = new List<TModel>();
            foreach (var name in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                permissionsEnumsList.Add(new TModel
                {
                    Id = Guid.NewGuid(),
                    PermissionName = name.ToString(),
                    PermissionDescription = "TODO",
                    RoleId = new Guid("1ef25ac2-b6d0-449e-bfaf-1ae2324d6781"),
                });
            }

            return permissionsEnumsList;
        }
    }
}
