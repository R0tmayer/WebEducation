using Auth.Domain.Models;

namespace Auth.DataAccess.Repositories;

public interface IUserRepository : IRepository<User>
{
    User GetByLogin(string login);
}