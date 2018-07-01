using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoContainer.Core.Domain;
using MemoContainer.Core.Repositories;

namespace MemoContainer.Infrastructure.Repositories
{
    public class MemoRepository : IMemoRepository
    {
        private readonly List<Memo> _memos;

        public MemoRepository()
        {
            _memos = new List<Memo>(); // todo - implement by DB
        }

        public async Task<IEnumerable<Memo>> BrowseAsync(string name = "")
        {
            var memos = _memos.AsEnumerable();
            if (String.IsNullOrWhiteSpace(name))
            {
                memos = memos.Where(memo => memo.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }
            return await Task.FromResult(memos);
        }

        public async Task<Memo> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_memos.SingleOrDefault(memo => memo.Id == id));
        }

        public async Task AddAsync(Memo memo)
        {
            _memos.Add(memo);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Memo memo)
        {
            _memos.Remove(memo);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Memo memo)
        {
            await Task.CompletedTask;
        }
    }
}