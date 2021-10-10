using Contact.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Application.Contracts.Persistence
{
	public interface IContactRepository : IAsyncRepository<ContactEntity>
	{
		Task<IEnumerable<ContactEntity>> GetContactByFirstName(string FirstName);
		Task<IEnumerable<ContactEntity>> GetContactByLastName(string LastName);
	}
}
