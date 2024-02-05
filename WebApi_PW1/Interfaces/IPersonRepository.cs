using WebApi_PW1.Models;

namespace WebApi_PW1.Interfaces;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<Person> CreatePerson(Person person);
    Task<Person?> GetPersonById(long id);
    Task<Person> UpdatePerson(Person person);
    Task<Person?> DeletePerson(Person person);
    
}