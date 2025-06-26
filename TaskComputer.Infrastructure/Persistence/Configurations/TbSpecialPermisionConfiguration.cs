using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using TaskComputer.Infrastructure.Entities;

namespace TaskComputer.Infrastructure.Persistence.Configuration
{
    public class TbSpecialPermisionConfiguration : IEntityTypeConfiguration<TbSpecialPermission>
    {
        public void Configure(EntityTypeBuilder<TbSpecialPermission> builder)
        {
            builder.HasKey(e => e.IdSpecialPermission);

            builder.ToTable("TB_SpecialPermission");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.TbSpecialPermissionIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_SpecialPermission_TB_User");

            builder.HasOne(d => d.IdUserActionNavigation).WithMany(p => p.TbSpecialPermissionIdUserActionNavigations)
                .HasForeignKey(d => d.IdUserAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_SpecialPermission_TB_User_Action");

            builder.HasOne(d => d.IdUserCreatedNavigation).WithMany(p => p.TbSpecialPermissionIdUserCreatedNavigations)
                .HasForeignKey(d => d.IdUserCreated)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_SpecialPermission_TB_User_Created");
        }
    }
}
