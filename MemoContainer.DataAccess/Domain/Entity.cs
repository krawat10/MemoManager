using System;

namespace MemoContainer.DataAccess.Domain
{
    public class Entity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
        
        protected void CheckAndThrowIfNullOrWhitespace(string word, string parameterName)
        {
            if (String.IsNullOrWhiteSpace(word))
            {
                throw new Exception($"Memo with id: {Id} can not have an empty {parameterName}");
            }
        }
    }
}