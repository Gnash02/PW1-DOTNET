using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Commands;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;

namespace WebApi_PW1.Handlers;

public class UpdatePersonHandler/*(IPersonRepository personRepository, PersonContext personContext)*/
    : IRequestHandler<UpdatePersonCommand,Person>
{
    private readonly IPersonRepository _personRepository /*= personRepository*/;
    private readonly PersonContext _personContext /*= personContext*/;

    public UpdatePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }


  

    public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        /*Person person = await _personContext.PersonItems.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (person == null)
        {
            throw new Exception("Record does not exist"+request.Id);
        }

        person.Age = request.Age;
        person.Name = request.Name;
        _personContext.Update(person);
        await _personContext.SaveChangesAsync(cancellationToken);
        return person;*/
        return await _personRepository.UpdatePerson(request.Id, request.Name, request.Age);
    }
}