using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;
using WebApi_PW1.Queries;

namespace WebApi_PW1.Handlers;

public class GetPersonHandler : IRequestHandler<GetPersonQuery, List<Person>>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Task<List<Person>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        return _personRepository.GetAll().ToListAsync();
    }
}