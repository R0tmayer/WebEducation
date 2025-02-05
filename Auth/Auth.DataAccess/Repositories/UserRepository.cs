using Auth.Domain.Models;

namespace Auth.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }

    public User GetById(int id)
    {
        throw new NotImplementedException();
    }

    public User GetByLogin(string login)
    {
        return _users.SingleOrDefault(user => user.Login == login);
    }

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User Create(User user)
    {
        var newUser = new User()
        {
            Id = GetNextUserId(),
            Login = user.Login,
            PasswordHash = user.PasswordHash,
            CreatedAt = DateTime.Now
        };

        _users.Add(newUser);
        return newUser;
    }

    public User Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    private int GetNextUserId()
    {
        return _users.Any() ? _users.Count : 1;
    }
}