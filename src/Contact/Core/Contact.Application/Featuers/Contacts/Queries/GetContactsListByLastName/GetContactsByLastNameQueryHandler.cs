using AutoMapper;
using Contact.Application.Contracts.Persistence;
using Contact.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Featuers.Contacts.Queries.GetContactsListByLastName
{
	public class GetContactsByLastNameQueryHandler : IRequestHandler<GetContactsListByLastNameQuery, List<ContactsLastNameVM>>
	{

		private readonly IContactRepository contactRepository;
		private readonly IMapper mapper;

		public GetContactsByLastNameQueryHandler(IContactRepository ContactRepository, IMapper Mapper)
		{
			this.contactRepository = ContactRepository;
			this.mapper = Mapper;
		}

		public async Task<List<ContactsLastNameVM>> Handle(GetContactsListByLastNameQuery request, CancellationToken cancellationToken)
		{
			IEnumerable<ContactEntity> contactList = await contactRepository.GetContactByLastName(request.LastName);
			return mapper.Map<List<ContactsLastNameVM>>(contactList);
		}
	}
}
