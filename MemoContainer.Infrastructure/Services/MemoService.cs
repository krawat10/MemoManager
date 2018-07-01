using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemoContainer.Core.Domain;
using MemoContainer.Core.Repositories;
using MemoContainer.Infrastructure.DTOs;

namespace MemoContainer.Infrastructure.Services
{
    class MemoService : IMemoService
    {
        private readonly IMemoRepository _memoRepository;
        private readonly IMapper _mapper;

        public MemoService(IMemoRepository memoRepository, IMapper mapper)
        {
            _memoRepository = memoRepository;
            _mapper = mapper;
        }

        public async Task<MemoDTO> GetByIdAsync(Guid id)
        {
            var memo = await _memoRepository.GetByIdAsync(id);
            if (memo == null)
            {
                throw new Exception($"Memo with id: {id} does not exists.");
            }

            return _mapper.Map<MemoDTO>(memo);
        }

        public async Task<IEnumerable<MemoDTO>> GetForUserAsync(Guid userId)
        {
            var allMemos = await _memoRepository.BrowseAsync();
            var userMemos = allMemos.Where(memo => memo.UserId == userId);

            return _mapper.Map<IEnumerable<MemoDTO>>(userMemos);

        }

        public async Task UpdateAsync(Guid id, string name, string description)
        {
            var memo = await _memoRepository.GetByIdAsync(id);
            if (memo == null)
            {
                throw new Exception($"Memo with id: {id} does not exists.");
            }

            memo.SetName(name);
            memo.SetDescription(description);
            await _memoRepository.UpdateAsync(memo);
        }

        public async Task FinishAsync(Guid id)
        {
            var memo = await _memoRepository.GetByIdAsync(id);
            if (memo == null)
            {
                throw new Exception($"Memo with id: {id} does not exists.");
            }

            memo.FinishMemo();
            await _memoRepository.UpdateAsync(memo);
        }

        public async Task CreateAsync(Guid id, string name, string description, Guid userId)
        {
            var memo = await _memoRepository.GetByIdAsync(id);
            if (memo != null)
            {
                throw new Exception($"Memo with id: {id} already exists.");
            }
            memo = new Memo(id, name, description, userId);
            await _memoRepository.AddAsync(memo);
        }
    }
}