using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    public interface IMemoService
    {
        Task<MemoDTO> GetByIdAsync(Guid id); 
        Task<IEnumerable<MemoDTO>> GetForUserAsync(Guid userId);
        Task UpdateAsync(Guid id, string name, string description);
        Task FinishAsync(Guid id);
        Task CreateAsync(Guid id, string name, string description, Guid userId);

    }
}