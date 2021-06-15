using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Validations;

namespace WebApi.PipelineBehaviors
{
    //Add Vaildation to MediatR pipeline
    // https://stackoverflow.com/questions/42283011/add-validation-to-a-mediatr-behavior-pipeline
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : List<ValidationResponse>, new()
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                                .Select(x => x.Validate(context))
                                .SelectMany(x => x.Errors)
                                .Where(x => x is not null)
                                .ToList();
            if (failures.Any())
            {
                //// Validation attempt - didn't work
                //List<ValidationResponse> errorResponses = new();

                //foreach (var failure in failures)
                //{
                //    ValidationResponse errorResponse = new()
                //    {
                //        ErrorCode = failure.ErrorCode,
                //        ErrorStatusCode = HttpStatusCode.BadRequest,
                //        ErrorMessage = failure.ErrorMessage,
                //        ErrorPropertyName = failure.PropertyName
                //    };

                //    errorResponses.Add(errorResponse);
                //}

                //TResponse response = new();


                //return (Task<TResponse>) errorResponses;
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
