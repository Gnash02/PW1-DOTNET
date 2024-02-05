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
        public async Task<IActionResult> AddPerson(Person person){
            var personCommand = new  AddPersonCommand(){person=person};
            var persons = await _mediator.Send(personCommand);
            return Ok(persons);
    }

        [HttpGet("GetAllPeople")]
        public async Task<IActionResult> GetPerson()
        {
            //string serializedcustomerlist; //was used for serialization dont need it rn 
            var persons = new List<Person>();
            persons = await _mediator.Send(new GetPersonQuery());
            //serializedcustomerlist = JsonConvert.SerializeObject(persons);  //same 
            return Ok(persons);
        }
        [HttpGet("GetPersonById")]
        public async Task<IActionResult> GetPersonById(long id)
        {
            //string serializedcustomerlist; //was used for serialization dont need it rn 
            var person = new Person();
            var getPersonByID = new GetPersonByIdQuery() { Id = id };
            person = await _mediator.Send(getPersonByID);
            //serializedcustomerlist = JsonConvert.SerializeObject(persons);  //same 
            return Ok(person);
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult>  DeletePersonById(long id)
        {
            var deletepersonCommand = new  DeletePersonByIdCommand(){id=id};
            await _mediator.Send(deletepersonCommand);
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
