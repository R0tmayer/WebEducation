using Auth.Domain.Models;

namespace Auth.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public User GetByLogin(string login)
    {
        return new User();
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User Create(User entity)
    {
        throw new NotImplementedException();
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}