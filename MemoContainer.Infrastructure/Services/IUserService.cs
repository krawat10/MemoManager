using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    public interface IUserService
    {
        Task RegisterAsync(Guid userId, string nickname, string email, string firstName, string lastName, string password, string role = "user");

        Task<TokenDTO> LoginByEmailAsync(string email, string password);

        Task<TokenDTO> LoginByNicknameAsync(string nickname, string password);

        Task<UserDTO> GetUserAsync(Guid userId);
    }
}