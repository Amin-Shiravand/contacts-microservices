using MediatR;

namespace Contact.Application.Featuers.Contacts.Commands.UpdateContact
{
	public class UpdateContactCommand : IRequest
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
	}
}
