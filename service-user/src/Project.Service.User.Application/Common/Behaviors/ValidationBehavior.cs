﻿using FluentValidation;
using MediatR;
using Newtonsoft.Json;

namespace Project.Service.User.Application.Common.Behaviors
{
    internal class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
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

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    var errors = failures.Select(i => i.ErrorMessage).ToList();
                    throw new ValidationException(JsonConvert.SerializeObject(errors));
                }
            }
            return await next();
        }
    }
}
