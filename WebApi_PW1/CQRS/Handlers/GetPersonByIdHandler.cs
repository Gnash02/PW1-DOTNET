using MediatR;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;
using WebApi_PW1.Queries;

namespace WebApi_PW1.Handlers;

public class GetPersonByIdHandler: IRequestHandler<GetPersonByIdQuery, Person>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonByIdHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return _personRepository.GetPersonById(request.Id);
    }
}