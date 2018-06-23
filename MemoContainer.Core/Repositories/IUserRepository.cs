using System;
using System.Threading.Tasks;
using MemoContainer.Core.Domain;

namespace MemoContainer.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByNicknameAsync(string nickname);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
    }
}