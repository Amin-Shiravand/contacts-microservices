using Contact.Application.Featuers.Contacts.Queries.GetContactsListByFirstName;
using MediatR;
using System.Collections.Generic;

namespace Contact.Application
{
	public class GetContactsListByFirstNameQuery : IRequest<List<ContactsFirstNameVM>>
	{
		public string FirstName { get; set; }

		public GetContactsListByFirstNameQuery(string FirstName)
		{
			this.FirstName = FirstName;
		}
	}
}