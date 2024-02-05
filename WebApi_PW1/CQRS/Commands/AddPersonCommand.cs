using MediatR;
using WebApi_PW1.Models;

namespace WebApi_PW1.Commands;

public class AddPersonCommand:IRequest<Person>
{
    public Person person { get; set; }
}