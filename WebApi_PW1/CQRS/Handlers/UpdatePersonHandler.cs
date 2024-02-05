using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Commands;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;

namespace WebApi_PW1.Handlers;

public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, Person>
{
    private readonly IPersonRepository _personRepository;
    private readonly PersonContext _personContext;

    public UpdatePersonHandler(IPersonRepository personRepository, PersonContext personContext)
    {
        _personRepository = personRepository;
        _personContext = personContext;
    }


    public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        Person person = await _personContext.PersonItems.SingleOrDefaultAsync(x => x.Id == request.Id);

        if (person == null)
        {
            throw new Exception("Record does not exist" + request.Id);
        }

        person.Name = request.Name;
        person.Age = request.Age;
        return await _personRepository.UpdatePerson(person);
    }
}