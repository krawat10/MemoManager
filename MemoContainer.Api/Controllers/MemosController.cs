using System;
using System.Linq;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.Commands;
using MemoContainer.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemoContainer.Api.Controllers
{
    [Route("[controller]")]
    public class MemosController : Controller
    {
        private readonly IMemoService _memoService;

        public MemosController(IMemoService memoService)
        {
            _memoService = memoService;
        }

        [HttpGet("{memoId}")]
        [Authorize]
        public async Task<ActionResult> Get(Guid memoId)
        {
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(User.Identity.Name) : Guid.Empty;
            var memos = await _memoService.GetForUserAsync(userId);

            var memo = memos.SingleOrDefault(dto => dto.Id == memoId);

            if (memo == null) return NotFound();

            return Json(memo);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post([FromBody] CreateMemo command)
        {
            if (User.Identity.IsAuthenticated)
            {
                command.UserId = Guid.Parse(User.Identity.Name);
                command.MemoId = Guid.NewGuid();
                await _memoService.CreateAsync(command.MemoId, command.Name, command.Description, command.UserId);
            }

            return Created($"memos/{command.MemoId}", null);
        }

        [HttpDelete("finish/{memoId}")]
        [Authorize]
        public async Task<ActionResult> Finish(Guid memoId)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var memos = await _memoService.GetForUserAsync(userId);

            if (memos.All(dto => dto.Id != memoId)) return NotFound();

            await _memoService.FinishAsync(memoId);

            return NoContent();
        }
    }
}