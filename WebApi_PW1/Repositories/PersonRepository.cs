using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;

namespace WebApi_PW1.Repositories;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    protected readonly PersonContext personContext;

    public PersonRepository(PersonContext context) : base(context)
    {
        personContext = context;
    }


    public async Task<Person> CreatePerson(Person person)
    {
        personContext.Add(person);
        await personContext.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> GetPersonById(long personid)
    {
        return await personContext.PersonItems.SingleOrDefaultAsync(x => x.Id == personid);
       
    }

    public async Task<Person> UpdatePerson(Person _person )
    {
      
        personContext.Update(_person);
        await personContext.SaveChangesAsync();
        return _person;
    }

    public Task<Person?> DeletePerson(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<Person?> DeletePerson(Person person)
    {
        

        personContext.PersonItems.Remove(person);
        await personContext.SaveChangesAsync();
        return person!;
    }
}


