using FluentValidation;
using System.Text.RegularExpressions;

namespace Contact.Application.Featuers.Contacts.Commands.UpdateContact
{
	public class UpdateContactCommandValidation : AbstractValidator<UpdateContactCommand>
	{
		public UpdateContactCommandValidation()
		{
			RuleFor(p => p.Id).NotEmpty().WithMessage("{Id} is required.").GreaterThan(0).WithMessage("{Id} Invalid ID.");
			RuleFor(p => p.FirstName).NotEmpty().WithMessage("{FirstName} is required").NotNull().MaximumLength(25).WithMessage("{FirstName} must not exceed 25 characters.");
			RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("{PhoneNumber} is reuired.")
				.MaximumLength(12).WithMessage("{PhoneNumber} must not exceed 12 characters.")
				.Custom((p, context) =>
				{
					if (!Regex.Match(p, @"((\+63)|0)[.\- ]?9[0-9]{2}[.\- ]?[0-9]{3}[.\- ]?[0-9]{4}").Success)
					{
						context.AddFailure("{PhoneNumeber} is not valid");
					}

				});

			RuleFor(p => p.EmailAddress).EmailAddress().When(p => !string.IsNullOrEmpty(p.EmailAddress));
		}
	}
}
