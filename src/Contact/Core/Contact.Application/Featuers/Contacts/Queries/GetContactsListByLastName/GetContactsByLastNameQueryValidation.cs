using FluentValidation;

namespace Contact.Application.Featuers.Contacts.Queries.GetContactsListByLastName
{
	class GetContactsByLastNameQueryValidation : AbstractValidator<GetContactsListByLastNameQuery>
	{
		public GetContactsByLastNameQueryValidation()
		{
			RuleFor(P => P.LastName).NotNull().NotEmpty().WithMessage("{LastName} is required")
				.MaximumLength(25).WithMessage("{LastName} must not exceed 25 characters.");
		}
	}
}
