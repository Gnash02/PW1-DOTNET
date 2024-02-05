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
        [HttpPost("Post")]
        public async Task<IActionResult> AddPerson( AddPersonCommand personCommand){
            var persons = await _mediator.Send(personCommand);
            return Ok(persons); 
        }

        [HttpGet("GetAllPeople")]
        public async Task<IActionResult> GetPerson([FromQuery]GetPersonQuery getAllQuery)
        {
            var persons = new List<Person>();
            persons = await _mediator.Send(getAllQuery);
            return Ok(persons);
        }
        [HttpGet("GetPersonById")]
        public async Task<IActionResult> GetPersonById([FromQuery]GetPersonByIdQuery getPersonByIdQuery)
        {
            var person = new Person();
            person = await _mediator.Send(getPersonByIdQuery);
            return Ok(person);
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult>  DeletePersonById(DeletePersonByIdCommand deletePersonByIdCommand)
        {
          
            await _mediator.Send(deletePersonByIdCommand);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult>  UpdatePerson(UpdatePersonCommand person)
        {
            var Person= await _mediator.Send(person);
            return Ok(person);
        }
        
}
}
