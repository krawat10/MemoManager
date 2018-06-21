using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    public interface IJwtHandler
    {
        Task<TokenDTO> CreateToken(Guid userId, string role);
    }
}