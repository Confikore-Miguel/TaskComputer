

using Microsoft.EntityFrameworkCore;
namespace TaskComputer.Application.Data
{
    public interface IApplicationDbContext
    {
        //Entidades
        //DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
