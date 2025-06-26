using TaskComputer.Domain.Entities;
using TaskComputer.Domain.Interfaces;
using TaskComputer.Infrastructure.Persistence;

namespace TaskComputer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskComputerContext _context;

        public UserRepository(TaskComputerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<TbUser> AddUserAsync(TbUser user)
        { 
            await _context.TbUsers.AddAsync(user);
            return user;
        }


        
    }

}
