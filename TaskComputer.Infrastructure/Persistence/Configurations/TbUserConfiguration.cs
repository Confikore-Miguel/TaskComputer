using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskComputer.Infrastructure.Entities;

namespace TaskComputer.Infrastructure.Persistence.Configuration
{
    public class TbUserConfiguration : IEntityTypeConfiguration<TbUser>
    {
        public void Configure(EntityTypeBuilder<TbUser> builder)
        {
            builder.HasKey(e => e.IdUser);

            builder.ToTable("TB_User");

            builder.Property(e => e.DateCreated).HasColumnType("datetime");
            builder.Property(e => e.DateRemoved).HasColumnType("datetime");
            builder.Property(e => e.DateUpdated).HasColumnType("datetime");
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Pass).HasMaxLength(16);

            builder.HasOne(d => d.IdRoleNavigation).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_User_TB_Role");
        }
    }
}
