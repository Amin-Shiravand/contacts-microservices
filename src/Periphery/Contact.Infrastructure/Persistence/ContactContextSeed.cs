using Contact.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Persistence
{
	public class ContactContextSeed
	{
		public static async Task SeedAsync(ContactContext ContactContext, ILogger<ContactContextSeed> Logger)
		{
			if (!ContactContext.Contacts.Any())
			{
				ContactContext.Contacts.AddRange(GetPreConfigContacts());
				await ContactContext.SaveChangesAsync();
				Logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ContactContext).Name);
			}
		}

		private static IEnumerable<ContactEntity> GetPreConfigContacts()
		{
			return new List<ContactEntity>
				{
					new ContactEntity
					{
						FirstName ="Amin",
						LastName = "Shiravand",
						PhoneNumber = "09109264410"
					}
				};
		}
	}
}
