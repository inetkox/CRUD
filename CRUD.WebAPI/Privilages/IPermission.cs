namespace CRUD.WebAPI.Privilages
{
    public interface IPermission<TModel, TModelIdType>
    {
        Guid Id { get; set; }
        string? PermissionDescription { get; set; }
        string? PermissionName { get; set; }
        Role? Role { get; set; }
        Guid RoleId { get; set; }
    }
}