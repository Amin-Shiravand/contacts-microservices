using MediatR;
using System.Collections.Generic;

namespace Contact.Application.Featuers.Contacts.Queries.GetContactsListByLastName
{
	public class GetContactsListByLastNameQuery : IRequest<List<ContactsLastNameVM>>
	{
		public string LastName { get; set; }

		public GetContactsListByLastNameQuery(string LastName)
		{
			this.LastName = LastName;
		}
	}
}
