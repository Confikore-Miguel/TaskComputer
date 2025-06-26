using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskComputer.Application.Features.User.DTOs;
using TaskComputer.Domain.Entities;

namespace TaskComputer.Application.Features.User.Commands
{
    public record CreateUserCommand(CreateUserDTO CreateUser) : IRequest<ErrorOr<TbUser>> ;
}
