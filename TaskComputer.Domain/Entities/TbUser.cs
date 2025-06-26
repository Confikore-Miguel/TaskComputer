using TaskComputer.Domain.Primitives;

namespace TaskComputer.Domain.Entities;

public partial class TbUser : AggregateRoot
{
    public int IdUser { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public bool Active { get; set; }

    public bool Removed { get; set; }

    public int IdRole { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateRemoved { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? IdUserAction { get; set; }

    public int IdUserCreated { get; set; }

    public virtual TbRole IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<TbPermission> TbPermissionIdUserActionNavigations { get; set; } = new List<TbPermission>();

    public virtual ICollection<TbPermission> TbPermissionIdUserCreatedNavigations { get; set; } = new List<TbPermission>();

    public virtual ICollection<TbRole> TbRoleIdUserActionNavigations { get; set; } = new List<TbRole>();

    public virtual ICollection<TbRole> TbRoleIdUserCreatedNavigations { get; set; } = new List<TbRole>();

    public virtual ICollection<TbSpecialPermission> TbSpecialPermissionIdUserActionNavigations { get; set; } = new List<TbSpecialPermission>();

    public virtual ICollection<TbSpecialPermission> TbSpecialPermissionIdUserCreatedNavigations { get; set; } = new List<TbSpecialPermission>();

    public virtual ICollection<TbSpecialPermission> TbSpecialPermissionIdUserNavigations { get; set; } = new List<TbSpecialPermission>();
}
