using FluentValidation;

namespace Contact.Application.Featuers.Contacts.Commands.DeleteContact
{
	public class DeleteContactCommandValidation : AbstractValidator<DeleteContactCommand>
	{
		public DeleteContactCommandValidation()
		{
			RuleFor(p => p.Id).GreaterThan(0).WithMessage("{Id} is invalid");
		}
	}
}
