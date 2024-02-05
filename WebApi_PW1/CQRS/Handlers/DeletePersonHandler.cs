using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Commands;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;
using static System.Console;

namespace WebApi_PW1.Handlers;

public class DeletePersonHandler : IRequestHandler<DeletePersonByIdCommand,Person?>
{

    private readonly IPersonRepository _personRepository ;
    private readonly PersonContext _personContext ;


    public DeletePersonHandler(IPersonRepository personRepository,PersonContext personContext)
    {
        _personRepository = personRepository;
        _personContext = personContext;
    }

    public async Task<Person?> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
    {
        Person person = await _personContext.PersonItems.SingleOrDefaultAsync(x => x.Id ==request.id);
        if (person == null)
        {
            throw new Exception("Record does not exist"+request.id);
            
        }
        return await _personRepository.DeletePerson(person);
    }
}