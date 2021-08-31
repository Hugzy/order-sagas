using System;

namespace RebusTest.EFCore.Models
{
    public abstract class ModelBase
    {
        public abstract int Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } 
        public DateTimeOffset UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{nameof(CreatedAt)}: {CreatedAt}, {nameof(UpdatedAt)}: {UpdatedAt}";
        }

        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        
    }
}