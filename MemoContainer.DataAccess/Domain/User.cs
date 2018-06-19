using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace MemoContainer.DataAccess.Domain
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Role { get; private set; }
        public string Email { get; private set; }

        public IEnumerable<Memo> Memos => _memos;
        public IEnumerable<Memo> FinishedMemos => _memos.Where(memo => memo.FinishetAt.HasValue);
        public IEnumerable<Memo> NotFinishedMemos => _memos.Except(FinishedMemos);

        public static readonly IEnumerable<string> Roles = new List<string>
        {
            "admin",
            "user"
        };

        private ISet<Memo> _memos = new HashSet<Memo>();

        public User(string firstName, string lastName, string role, string email)
        {
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetRole(role);
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

            if (!Roles.Contains(role.ToLowerInvariant()))
            {
                throw new Exception("Incorrect role.");
            }

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