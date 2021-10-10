using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Contact.Application.Exceptions
{
	public class ValidationException : ApplicationException
	{
		public IDictionary<string, string[]> Errors { get; }

		public ValidationException() : base("One or more Validation failures have occured")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IEnumerable<ValidationFailure> Failures)
			: this()
		{
			Errors = Failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).
				ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
		}
	}
}
