using FluentValidation;
using FluentValidation.Results;
using MediatR;
using WebApi_PW1.Interfaces;

namespace WebApi_PW1.Handlers.Validators;

public sealed class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public
        Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
    {
        //throw new NotImplementedException();
        var context = new ValidationContext<TRequest>(request);
        /*var validationFailures = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context)));
        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage))
            .ToList();*/
        var failures = _validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null)
            .ToList();
        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        return next();


        //return default;
    }
}