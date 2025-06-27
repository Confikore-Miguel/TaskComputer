using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskComputer.Application.Common.Behaviors
{
    internal class ValidationBehavior<TResquest, TResponse> : IPipelineBehavior<TResquest, TResponse>
    where TResquest : IRequest<TResponse>
    where TResponse : IErrorOr
    {
        private readonly IValidator<TResquest>? _validator;

        public ValidationBehavior(IValidator<TResquest>? validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TResquest request, 
            RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validator is null)
                return await next(cancellationToken);
            
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if(validationResult.IsValid)
                return await next(cancellationToken);

            var errors = validationResult.Errors
                         .ConvertAll( validationFailure => Error.Validation(
                             validationFailure.PropertyName, 
                             validationFailure.ErrorMessage
                         ));

            return (dynamic)errors;
        }
    }
}
