using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Contact.Application.Featuers.Contacts.Queries.GetContactsListByFirstName;
using Contact.Application;
using Contact.Application.Featuers.Contacts.Queries.GetContactsListByLastName;
using Contact.Application.Featuers.Contacts.Commands.AddContact;
using Contact.Application.Featuers.Contacts.Commands.UpdateContact;
using Contact.Application.Featuers.Contacts.Commands.DeleteContact;

namespace Contact.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ContactController : ControllerBase
	{
		private readonly IMediator mediator;

		public ContactController(IMediator Mediator)
		{
			this.mediator = Mediator;
		}

		[HttpGet("[Action]/{FirstName}", Name = "GetContactByFirstName")]
		[ProducesResponseType(typeof(IEnumerable<ContactsFirstNameVM>), StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<ContactsFirstNameVM>>> GetContactByFirstName(string FirstName)
		{
			GetContactsListByFirstNameQuery query = new GetContactsListByFirstNameQuery(FirstName);
			List<ContactsFirstNameVM> contacts = await mediator.Send(query);
			return Ok(contacts);
		}

		[HttpGet("[Action]/{LastName}", Name = "GetContactByLastName")]
		[ProducesResponseType(typeof(IEnumerable<ContactsLastNameVM>),StatusCodes.Status200OK)]
		public async Task<ActionResult<IEnumerable<ContactsLastNameVM>>> GetContactByLastName(string LastName)
		{
			GetContactsListByLastNameQuery query = new GetContactsListByLastNameQuery(LastName);
			List<ContactsLastNameVM> contacts = await mediator.Send(query);
			return Ok(contacts);
		}

		[HttpPost(Name = "AddContacts")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> AddContacts([FromBody] AddContactCommand Command)
		{
			int result = await mediator.Send(Command);
			return Ok(result);
		}

		[HttpPut(Name ="UpdateContact")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> UpdateContact([FromBody] UpdateContactCommand Command)
		{
			await mediator.Send(Command);
			return NoContent();
		}


		[HttpDelete("{Id}" ,Name = "DeleteContact")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> DeleteContact(int Id)
		{
			DeleteContactCommand command = new DeleteContactCommand { Id = Id };
			await mediator.Send(command);
			return NoContent();
		}
	}
}
