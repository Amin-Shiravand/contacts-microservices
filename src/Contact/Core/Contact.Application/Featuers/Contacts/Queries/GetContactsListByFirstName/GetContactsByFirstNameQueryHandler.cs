using AutoMapper;
using MediatR;
using Contact.Application.Contracts.Persistence;
using Contact.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Featuers.Contacts.Queries.GetContactsListByFirstName
{
	public class GetContactsByFirstNameQueryHandler : IRequestHandler<GetContactsListByFirstNameQuery, List<ContactsFirstNameVM>>
	{
		private readonly IContactRepository contactRepository;
		private readonly IMapper mapper;

		public GetContactsByFirstNameQueryHandler(IContactRepository ContactRepository, IMapper Mapper)
		{
			this.contactRepository = ContactRepository;
			this.mapper = Mapper;
		}

		public async Task<List<ContactsFirstNameVM>> Handle(GetContactsListByFirstNameQuery request, CancellationToken cancellationToken)
		{
			IEnumerable<ContactEntity> contactList = await contactRepository.GetContactByFirstName(request.FirstName);
			return mapper.Map<List<ContactsFirstNameVM>>(contactList);
		}
	}
}
