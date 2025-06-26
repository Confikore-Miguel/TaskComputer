using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskComputer.Domain.Entities;

namespace TaskComputer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<TbUser> AddUserAsync(TbUser user);
    }
}
