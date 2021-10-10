using AutoMapper;
using Contact.Application.Contracts.Persistence;
using Contact.Application.Exceptions;
using Contact.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Featuers.Contacts.Commands.UpdateContact
{
	public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
	{
		private readonly IContactRepository contactRepository;
		private readonly IMapper mapper;
		private readonly ILogger<UpdateContactCommandHandler> logger;

		public UpdateContactCommandHandler(IContactRepository ContactRepository,
			IMapper Mapper,
			ILogger<UpdateContactCommandHandler> Logger)
		{
			this.contactRepository = ContactRepository;
			this.mapper = Mapper;
			this.logger = Logger;
		}

		public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
		{
			ContactEntity contactToUpdate = await contactRepository.GetByIdAsync(request.Id);
			if (contactToUpdate == null)
			{
				throw new NotFoundException(nameof(Contact), request.Id);
			}
			mapper.Map(request, contactToUpdate, typeof(UpdateContactCommand), typeof(ContactEntity));
			await contactRepository.UpdatedAsync(contactToUpdate);

			logger.LogInformation($"Contact {contactToUpdate.Id} is successfully updated.");
			return Unit.Value;
		}
	}
}
