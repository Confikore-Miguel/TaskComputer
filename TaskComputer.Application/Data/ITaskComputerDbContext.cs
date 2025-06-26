

using Microsoft.EntityFrameworkCore;
using TaskComputer.Domain.Entities;
namespace TaskComputer.Application.Data
{
    public interface ITaskComputerDbContext
    {
        //Entidades
        DbSet<TbPermission> TbPermissions { get; set; }
        DbSet<TbRole> TbRoles { get; set; }
        DbSet<TbRolePermission> TbRolePermissions { get; set; }
        DbSet<TbSpecialPermission> TbSpecialPermissions { get; set; }
        DbSet<TbUser> TbUsers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
