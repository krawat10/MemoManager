using System;

namespace MemoContainer.Infrastructure.Commands
{
    public class CreateMemo
    {
        public Guid MemoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}