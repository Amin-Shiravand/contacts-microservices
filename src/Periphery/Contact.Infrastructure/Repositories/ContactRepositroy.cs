using Contact.Application.Contracts.Persistence;
using Contact.Domain.Entities;
using Contact.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
	public class ContactRepositroy : RepositoryBase<ContactEntity>, IContactRepository
	{
		public ContactRepositroy(ContactContext DbContext) : base(DbContext)
		{
		}

		public async Task<IEnumerable<ContactEntity>> GetContactByFirstName(string FirstName)
		{
			List<ContactEntity> contactList = await dbContext.Contacts.Where(o => o.FirstName == FirstName).ToListAsync();
			return contactList;
		}

		public async Task<IEnumerable<ContactEntity>> GetContactByLastName(string LastName)
		{
			List<ContactEntity> contactList = await dbContext.Contacts.Where(o => o.LastName == LastName).ToListAsync();
			return contactList;
		}
	}
}
