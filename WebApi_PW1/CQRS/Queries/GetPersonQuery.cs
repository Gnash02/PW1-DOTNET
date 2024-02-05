using MediatR;
using WebApi_PW1.Models;

namespace WebApi_PW1.Queries;

public class GetPersonQuery : IRequest<List<Person>>
{
    IEnumerable<Person> person;
}