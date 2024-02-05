using MediatR;
using WebApi_PW1.Models;

namespace WebApi_PW1.Commands;

public class DeletePersonByIdCommand: IRequest<Person?>
{
    public long id { get; set; }
}