namespace WebApi_PW1.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(int id);
    IQueryable<T> GetAll();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);

    void DeleteById(int id);
}