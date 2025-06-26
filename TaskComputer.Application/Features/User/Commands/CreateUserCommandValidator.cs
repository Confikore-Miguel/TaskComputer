using FluentValidation;
namespace TaskComputer.Application.Features.User.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.CreateUser.Name)
                .MinimumLength(2)
                .NotEmpty()
                .WithMessage("Name is required.");
            RuleFor(x => x.CreateUser.LastName)
                .MinimumLength(2)
                .NotEmpty()
                .WithMessage("Last name is required.");
            RuleFor(x => x.CreateUser.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Valid email is required.");
            RuleFor(x => x.CreateUser.Pass)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.CreateUser.IdRole)
                .GreaterThan(0)
                .WithMessage("Role ID must be greater than 0.");
        }
    }
}
