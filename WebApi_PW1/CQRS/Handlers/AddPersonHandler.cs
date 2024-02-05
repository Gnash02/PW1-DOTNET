using MediatR;
using WebApi_PW1.Commands;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;

namespace WebApi_PW1.Handlers;

public class AddPersonHandler : IRequestHandler<AddPersonCommand, Person>
{
    private readonly IPersonRepository _personRepository;

    public AddPersonHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Name = request.Name,
            Age = request.Age,
            Id = request.Id
        };
        return await _personRepository.CreatePerson(person);
    }
}