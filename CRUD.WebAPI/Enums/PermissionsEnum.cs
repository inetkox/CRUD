namespace CRUD.WebAPI.Enums
{
    public class PermissionEnum
    {
        [Flags]
        public enum PermissionsEnums
        {
            GetAll,
            Get,
            Create,
            Update,
            Delete
        }
    }
}
