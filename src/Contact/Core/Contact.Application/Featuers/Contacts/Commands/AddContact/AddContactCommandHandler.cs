using AutoMapper;
using Contact.Application.Contracts.Persistence;
using Contact.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Featuers.Contacts.Commands.AddContact
{
	public class AddContactCommandHandler : IRequestHandler<AddContactCommand, int>
	{
		private readonly IContactRepository contactRepository;
		private readonly ILogger<AddContactCommandHandler> logger;
		private readonly IMapper mapper;

		public AddContactCommandHandler(IContactRepository ContactRepository,
			ILogger<AddContactCommandHandler> Logger
			, IMapper Mapper)
		{
			this.contactRepository = ContactRepository;
			this.logger = Logger;
			this.mapper = Mapper;
		}

		public async Task<int> Handle(AddContactCommand request, CancellationToken cancellationToken)
		{
			ContactEntity contact = mapper.Map<ContactEntity>(request);
			ContactEntity newContact = await contactRepository.AddAsync(contact);
			logger.LogInformation($"Contact {newContact.Id} is successfully created");
			return newContact.Id;
		}
	}
}
