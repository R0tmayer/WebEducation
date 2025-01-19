namespace Auth.DataAccess.Repositories;

public interface IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    T Create(T entity);
    T Update(T entity);
    void Delete(int id);
}