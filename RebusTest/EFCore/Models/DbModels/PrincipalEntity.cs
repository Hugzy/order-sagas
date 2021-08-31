using System;
using System.Collections.Generic;

namespace RebusTest.EFCore.Models.DbModels
{
    public class PrincipalEntity : ModelBase
    {
        public override int Id { get; set; }
        public string Text { get; set; }
        
        public DependantEntity DependantEntities { get; set; }

        protected bool Equals(PrincipalEntity other)
        {
            return Id == other.Id && Text == other.Text && Equals(DependantEntities, other.DependantEntities);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PrincipalEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text, DependantEntities);
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Id)}: {Id}, {nameof(Text)}: {Text}";
        }
    }
}