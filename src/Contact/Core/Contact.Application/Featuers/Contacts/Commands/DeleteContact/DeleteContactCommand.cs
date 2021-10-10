using MediatR;


namespace Contact.Application.Featuers.Contacts.Commands.DeleteContact
{
	public class DeleteContactCommand : IRequest
	{
		public int Id { get; set; }
	}
}
