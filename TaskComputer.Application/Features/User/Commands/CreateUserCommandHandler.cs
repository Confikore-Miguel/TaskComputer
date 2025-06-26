using ErrorOr;
using MediatR;
using TaskComputer.Application.Features.User.DTOs;
using TaskComputer.Domain.DomainErrors;
using TaskComputer.Domain.Entities;
using TaskComputer.Domain.Interfaces;
using TaskComputer.Domain.Primitives;
using TaskComputer.Domain.ValueObjects;

namespace TaskComputer.Application.Features.User.Commands
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<TbUser>>
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public async Task<ErrorOr<TbUser>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (Email.Create(request.CreateUser.Email) is not Email email)
                return Errors.User.EmailNotValid;

            var user = new TbUser
            {
                Name = request.CreateUser.Name,
                LastName = request.CreateUser.LastName,
                Email = request.CreateUser.Email,
                Pass = request.CreateUser.Pass,
                IdRole = request.CreateUser.IdRole,
                Active = request.CreateUser.Active,
                IdUserAction = request.CreateUser.IdUserAction,
                IdUserCreated = request.CreateUser.IdUserAction,
                Removed = false,
                DateCreated = DateTime.UtcNow,
                DateRemoved = null,
                DateUpdated = null
            };

            await _userRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
