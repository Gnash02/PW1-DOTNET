using MediatR;
using WebApi_PW1.Models;

namespace WebApi_PW1.Queries;

public class GetPersonByIdQuery:IRequest<Person>
{
    public long Id { get; set; }
}