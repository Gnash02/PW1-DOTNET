using MediatR;
using WebApi_PW1.Models;

namespace WebApi_PW1.Commands;

public class AddPersonCommand : IRequest<Person>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    
}