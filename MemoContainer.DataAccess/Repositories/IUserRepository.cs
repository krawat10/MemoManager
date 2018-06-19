using System;
using System.Threading.Tasks;
using MemoContainer.DataAccess.Domain;

namespace MemoContainer.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
    }
}