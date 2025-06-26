using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskComputer.Application.Data;
using TaskComputer.Domain.Entities;
using TaskComputer.Domain.Primitives;

namespace TaskComputer.Infrastructure.Persistence;

public class TaskComputerContext : DbContext, ITaskComputerDbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;

    // Updated properties to match the interface requirements  
    public DbSet<TbPermission> TbPermissions { get; set; }
    public DbSet<TbRole> TbRoles { get; set; }
    public DbSet<TbRolePermission> TbRolePermissions { get; set; }
    public DbSet<TbSpecialPermission> TbSpecialPermissions { get; set; }
    public DbSet<TbUser> TbUsers { get; set; }

    public TaskComputerContext()
    {
    }

    public TaskComputerContext(DbContextOptions options, IPublisher publisher) : base(options)
    {
        _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskComputerContext).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var domainEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.GetDomainEvents().Any())
            .SelectMany(e => e.GetDomainEvents());
        var result = await base.SaveChangesAsync(cancellationToken);
        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
        return result;
    }

}
