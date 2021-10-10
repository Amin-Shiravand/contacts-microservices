using FluentValidation;

namespace Contact.Application.Featuers.Contacts.Queries.GetContactsListByFirstName
{
	public class GetContactsByFirstNameQueryValidation : AbstractValidator<GetContactsListByFirstNameQuery>
	{
		public GetContactsByFirstNameQueryValidation()
		{
			RuleFor(P => P.FirstName).NotNull().NotEmpty().WithMessage("{FirstName} is required")
				.MaximumLength(25).WithMessage("{FirstName} must not exceed 25 characters.");
		}
	}
}
