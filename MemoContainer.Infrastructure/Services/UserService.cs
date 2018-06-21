using System;
using System.Threading.Tasks;
using MemoContainer.Core.Domain;
using MemoContainer.Core.Repositories;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(Guid userId, string email, string firstName, string lastName, string password, string role = "user")
        {
            var user = new User(userId, firstName, lastName, role, email, password);
            await _userRepository.AddAsync(user);
        }

        public async Task<TokenDTO> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            if(user.Password != password)
            {
                throw new Exception("Invalid credentials");
            }

        }

        public Task<AccountDTO> GetAccountAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}