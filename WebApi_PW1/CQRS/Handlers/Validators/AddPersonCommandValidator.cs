using FluentValidation;
using WebApi_PW1.Commands;
using WebApi_PW1.Models;

namespace WebApi_PW1.Handlers.Validators;

public class AddPersonCommandValidator:AbstractValidator<AddPersonCommand>
{
   public AddPersonCommandValidator()
   {
      RuleFor(x => x.Name).NotEmpty().WithMessage("the person's name cannot be empty");
      RuleFor(x => x.Name).Matches(@"^[a-zA-Z]+$").WithMessage("Name must be  valid string");   
      RuleFor(x => x.Age).GreaterThan(15).WithMessage("The age must be greater than 15 yo");
      RuleFor(x => x.Age).NotEmpty().WithMessage("the age cannot be empty");
      RuleFor(x => x.Age).NotNull().WithMessage("the age cannot be null");

   } 
}