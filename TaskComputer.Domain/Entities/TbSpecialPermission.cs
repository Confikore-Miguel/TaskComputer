
using TaskComputer.Domain.Primitives;

namespace TaskComputer.Domain.Entities;

public partial class TbSpecialPermission : AggregateRoot
{
    public int IdSpecialPermission { get; set; }

    public int SpecialPermissionName { get; set; }

    public int IdPermission { get; set; }

    public int IdUser { get; set; }

    public int Active { get; set; }

    public int Removed { get; set; }

    public int DateCreated { get; set; }

    public int? DateRemoved { get; set; }

    public int? DateUpdate { get; set; }

    public int IdUserAction { get; set; }

    public int IdUserCreated { get; set; }

    public virtual TbUser IdUserActionNavigation { get; set; } = null!;

    public virtual TbUser IdUserCreatedNavigation { get; set; } = null!;

    public virtual TbUser IdUserNavigation { get; set; } = null!;
}
