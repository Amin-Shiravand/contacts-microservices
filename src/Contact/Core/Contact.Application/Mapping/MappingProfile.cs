using AutoMapper;
using Contact.Application.Featuers.Contacts.Commands.AddContact;
using Contact.Application.Featuers.Contacts.Commands.UpdateContact;
using Contact.Application.Featuers.Contacts.Queries.GetContactsListByFirstName;
using Contact.Application.Featuers.Contacts.Queries.GetContactsListByLastName;
using Contact.Domain.Entities;


namespace Contact.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ContactEntity,ContactsFirstNameVM>().ReverseMap();
			CreateMap<ContactEntity,ContactsLastNameVM>().ReverseMap();
			CreateMap<ContactEntity, AddContactCommand>().ReverseMap();
			CreateMap<ContactEntity, UpdateContactCommand>().ReverseMap(); 
		}
	}
}
