using WebApi_PW1.Models;

namespace WebApi_PW1.Interfaces;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<Person> CreatePerson(Person person);
    Task<Person?> GetPersonById(long id);
    Task<Person> UpdatePerson(long Id, string Name, int Age);
    Task<Person?> DeletePerson(long id);
    
}