using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Contact.Application.Behaviors
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> Validators)
		{
			this.validators = Validators;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			if (validators.Any())
			{
				ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
				FluentValidation.Results.ValidationResult[] validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
				List<ValidationFailure> failures = new List<ValidationFailure>();

				for(int i =0; i < validationResults.Length; ++i)
				{
					List<ValidationFailure> errors = validationResults[i].Errors;
					int len = validationResults[i].Errors.Count;
					for(int j = 0; j < len; ++j)
					{
						ValidationFailure error = errors[j];
						if (errors != null)
						{
							failures.Add(error);
						}
					}
				}

				if (failures.Count != 0)
				{
					throw new Exceptions.ValidationException(failures);
				}
			}

			return await next();
		}
	}
}
