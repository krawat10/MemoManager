using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoContainer.Core.Domain;
using MemoContainer.Core.Repositories;

namespace MemoContainer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User(Guid.NewGuid(), "krawat10", "Mateusz", "Krawczyk", "admin", "krawat10@gmail.com", "P@ssw0rd")
            };

        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.Id == id));
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.Email == email));
        }

        public async Task<User> GetByNicknameAsync(string nickname)
        {
            return await Task.FromResult(_users.SingleOrDefault(user => user.Nickname == nickname));
        }

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(User user)
        {
            _users.Remove(user);
            await Task.CompletedTask;
        }
    }
}