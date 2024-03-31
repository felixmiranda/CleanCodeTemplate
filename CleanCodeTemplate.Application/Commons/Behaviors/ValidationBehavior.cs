using FluentValidation;
using MediatR;

namespace CleanCodeTemplate.Application;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TRequest>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResult = await Task
                .WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

            var failures = validationResult
                    .Where(x => x.Errors.Count != 0)
                    .SelectMany(x => x.Errors)
                    .Select(x => new BaseError()
                    {
                        PropertyName = x.PropertyName,
                        ErrorMessage = x.ErrorMessage
                    }).ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }
        return await next();
    }
}
