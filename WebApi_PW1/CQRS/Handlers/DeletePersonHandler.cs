using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Commands;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;
using static System.Console;

namespace WebApi_PW1.Handlers;

public class DeletePersonHandler/*(IPersonRepository personRepository, PersonContext personContext)*/
    : IRequestHandler<DeletePersonByIdCommand,Person?>
{

    private readonly IPersonRepository _personRepository ;
    private readonly PersonContext _personContext ;


    public DeletePersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    /*public async Task Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
    {
        var person = await _personContext.PersonItems.SingleOrDefaultAsync(x => x.Id == request.id, cancellationToken: cancellationToken);
        if (person == null)
        {
            throw new Exception("Record does not exist"+request.id);
        }

        _personContext.PersonItems.Remove(person);
        await _personContext.SaveChangesAsync(cancellationToken);
       
    }*/

    public async Task<Person?> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
    {
        return await _personRepository.DeletePerson(request.id);
    }
}