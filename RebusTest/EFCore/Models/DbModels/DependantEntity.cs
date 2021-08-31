using System;
using System.Collections.Generic;

namespace RebusTest.EFCore.Models.DbModels
{
    public class DependantEntity : ModelBase
    {
        public override int Id { get; set; }
        public string Text { get; set; }
        public int PrincipalEntityId { get; set; }
        public PrincipalEntity PrincipalEntity { get; set; }

        protected bool Equals(DependantEntity other)
        {
            return Id == other.Id && Text == other.Text && PrincipalEntityId == other.PrincipalEntityId && Equals(PrincipalEntity, other.PrincipalEntity);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DependantEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Text, PrincipalEntityId, PrincipalEntity);
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Id)}: {Id}, {nameof(Text)}: {Text}, {nameof(PrincipalEntityId)}: {PrincipalEntityId}, {nameof(PrincipalEntity)}: {PrincipalEntity}";
        }
    }
}