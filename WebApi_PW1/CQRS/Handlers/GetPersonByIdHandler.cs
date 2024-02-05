using MediatR;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;
using WebApi_PW1.Queries;

namespace WebApi_PW1.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person>
{
    private readonly IPersonRepository _personRepository;
    private readonly PersonContext _personContext;
    public GetPersonByIdHandler(IPersonRepository personRepository,PersonContext personContext)
    {
        _personRepository = personRepository;
        _personContext = personContext;
    }

    public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = _personRepository.GetPersonById(request.Id);
        if (person != null)
        {
            return await person;

        }
        throw new Exception("Record does not exist" + request.Id);

       
    }
}