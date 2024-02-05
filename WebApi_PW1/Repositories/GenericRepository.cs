using Microsoft.EntityFrameworkCore;
using WebApi_PW1.Interfaces;
using WebApi_PW1.Models;

namespace WebApi_PW1.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PersonContext personContext;

    public GenericRepository(PersonContext appDbContext)
    {
        personContext = appDbContext;
    }

    public Task Add(T entity)
    {
        personContext.Set<T>().Add(entity);
        return Task.CompletedTask;
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        personContext.Set<T>().Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return personContext.Set<T>().AsNoTracking();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}