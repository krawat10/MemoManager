using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    public interface ITokenProvider
    {
        TokenDTO GetToken(Guid userId, string role);
    }
}