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

    public async Task<Person> UpdatePerson(long Id,string Name,int Age )
    {
        Person person = await personContext.PersonItems.SingleOrDefaultAsync(x => x.Id ==Id);
        if (person == null)
        {
            throw new Exception("Record does not exist"+Id);
        }

        person.Age = Age;
        person.Name = Name;
        personContext.Update(person);
        await personContext.SaveChangesAsync();
        return person;
    }

    public async Task<Person?> DeletePerson(long id)
    {
        var person = await personContext.PersonItems.SingleOrDefaultAsync(x => x.Id == id);
        if (person == null)
        {
            throw new Exception("Record does not exist"+id);
        }

        personContext.PersonItems.Remove(person);
        await personContext.SaveChangesAsync();
        return person!;
    }
}


