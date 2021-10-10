using MediatR;

namespace Contact.Application.Featuers.Contacts.Commands.AddContact
{
	public class AddContactCommand : IRequest<int>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
	}
}
