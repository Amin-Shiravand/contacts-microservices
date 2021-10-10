using AutoMapper;
using Contact.Application.Contracts.Persistence;
using Contact.Application.Exceptions;
using Contact.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Contact.Application.Featuers.Contacts.Commands.DeleteContact
{
	public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
	{
		private readonly IContactRepository repository;
		private readonly IMapper mapper;
		private readonly ILogger<DeleteContactCommandHandler> logger;

		public DeleteContactCommandHandler(IContactRepository Repository,
			IMapper Mapper, 
			ILogger<DeleteContactCommandHandler> Logger)
		{
			this.repository = Repository;
			this.mapper = Mapper;
			this.logger = Logger;
		}

		public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
		{
			ContactEntity contact = await repository.GetByIdAsync(request.Id);
			if(contact == null)
			{
				throw new NotFoundException(nameof(ContactEntity), request.Id);
			}
			await repository.DeleteAsync(contact);
			logger.LogInformation($"Contact{contact.Id} is successfully deleted.");
			return Unit.Value;
		}
	}
}
