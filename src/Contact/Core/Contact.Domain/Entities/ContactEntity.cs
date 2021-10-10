using Contact.Domain.Common;

namespace Contact.Domain.Entities
{
	public class ContactEntity : EntityBase
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }
	}
}
