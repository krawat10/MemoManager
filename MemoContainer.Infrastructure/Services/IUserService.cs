using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(Guid userId, string email, string firstName, string lastName, string password, string role = "user");

        Task<TokenDTO> LoginAsync(string email, string password);

        Task<AccountDTO> GetAccountAsync(Guid userId);
    }
}