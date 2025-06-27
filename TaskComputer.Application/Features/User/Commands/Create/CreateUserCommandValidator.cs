using FluentValidation;
namespace TaskComputer.Application.Features.User.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.CreateUser)
                .NotNull()
                .WithMessage("El objeto CreateUser no puede ser nulo.");

            RuleFor(x => x.CreateUser.Name)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name Es requerido.");
            RuleFor(x => x.CreateUser.LastName)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull()
                .WithMessage("LastName Es requerido.");
            RuleFor(x => x.CreateUser.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithMessage("Email Validar correo.");
            RuleFor(x => x.CreateUser.Pass)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6)
                .WithMessage("Pass Debe tener minímo 6 carácteres.");
            RuleFor(x => x.CreateUser.IdRole)
                .GreaterThan(0)
                .NotNull()
                .WithMessage("IdRole Debe ser mayora 0");
        }
    }
}
