using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi_PW1.Commands;
using WebApi_PW1.Models;
using WebApi_PW1.Queries;

namespace WebApi_PW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(AddPersonCommand personCommand)
        {
            var persons = await _mediator.Send(personCommand);
            return Ok(persons);
        }

        [HttpGet]
        public async Task<IActionResult> GetPerson()
        {
            var persons = await _mediator.Send(new GetPersonQuery());
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(long id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery() { Id = id });
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonById(DeletePersonByIdCommand deletePersonByIdCommand)
        {
            await _mediator.Send(deletePersonByIdCommand);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson( UpdatePersonCommand person)
        {
            var Person = await _mediator.Send(person);
            return Ok(Person);
        }
    }
}