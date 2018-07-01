using System;

namespace MemoContainer.Infrastructure.DTOs
{
    public class MemoDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? FinishetAt { get; set; }

    }
}