using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoContainer.Core.Domain;

namespace MemoContainer.Core.Repositories
{
    public interface IMemoRepository
    {
        Task<IEnumerable<Memo>> BrowseAsync(string name = "");
        Task<Memo> GetByIdAsync(Guid id);
        Task AddAsync(Memo memo);
        Task RemoveAsync(Memo memo);
        Task UpdateAsync(Memo memo);
    }
}