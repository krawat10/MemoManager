using System;

namespace MemoContainer.DataAccess.Domain
{
    public class Memo : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? FinishetAt { get; private set; }
        public Guid UserId { get; private set; }

        public Memo(string name, string description, Guid userId)
        {
            SetName(name);
            SetDescription(description);
            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            CheckAndThrowIfNullOrWhitespace(name, nameof(name));

            CheckOrThrowIfFinished();

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDescription(string description)
        {
            CheckAndThrowIfNullOrWhitespace(description, nameof(description));

            if (description.Length > 200)
            {
                throw new Exception($"Memo with id: {Id} can not have description with length greather than 200");
            }

            CheckOrThrowIfFinished();

            Description = description;
            UpdatedAt = DateTime.UtcNow;
        }

        private void CheckOrThrowIfFinished()
        {
            if (FinishetAt != null)
            {
                throw new Exception($"Memo with id: {Id} can not be changed because is finished");
            }
        }

        public void FinishMemo()
        {
            UpdatedAt = DateTime.UtcNow;
            FinishetAt = DateTime.UtcNow;
        }
    }
}