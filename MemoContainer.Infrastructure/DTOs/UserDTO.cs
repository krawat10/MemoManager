using System;

namespace MemoContainer.Infrastructure.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Nickname { get; set; }
    }
}