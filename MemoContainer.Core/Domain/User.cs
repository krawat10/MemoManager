using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MemoContainer.Core.Domain
{
    public class User : Entity
    {
        public static readonly IEnumerable<string> Roles = new List<string>
        {
            "admin",
            "user"
        };

        private readonly ISet<Memo> _memos = new HashSet<Memo>();

        public User(Guid id, string nickname, string firstName, string lastName, string role, string email, string password)
            : base(id)
        {
            SetNickname(nickname);
            SetPassword(password);
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetRole(role);
        }

        private void SetNickname(string nickname)
        {
            CheckAndThrowIfNullOrWhitespace(nickname, nameof(nickname));
            Nickname = nickname;
        }

        public string Nickname { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public IEnumerable<Memo> Memos => _memos;
        public IEnumerable<Memo> FinishedMemos => _memos.Where(memo => memo.FinishetAt.HasValue);
        public IEnumerable<Memo> NotFinishedMemos => _memos.Except(FinishedMemos);

        private void SetPassword(string password)
        {
            CheckAndThrowIfNullOrWhitespace(password, nameof(password));

            var regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$");

            if (!regex.IsMatch(password))
                throw new Exception($"User with id: {Id} must have password " +
                                    $"with length between 8 and 15 symbols and" +
                                    $" at least 1 number, 1 lowercase letter," +
                                    $" 1 uppercase letter and special character.");

            Password = password;
        }

        public void SetEmail(string email)
        {
            CheckAndThrowIfNullOrWhitespace(email, nameof(email));

            try
            {
                new MailAddress(email);
            }
            catch (FormatException)
            {
                throw new Exception("Incorrect email format");
            }

            Email = email;
        }

        public void SetRole(string role)
        {
            CheckAndThrowIfNullOrWhitespace(role, nameof(role));

            if (!Roles.Contains(role.ToLowerInvariant())) throw new Exception("Incorrect role.");

            Role = role;
        }

        public void SetLastName(string lastName)
        {
            CheckAndThrowIfNullOrWhitespace(lastName, nameof(lastName));
            LastName = lastName;
        }

        public void SetFirstName(string firstName)
        {
            CheckAndThrowIfNullOrWhitespace(firstName, nameof(firstName));
            FirstName = firstName;
        }
    }
}