using System;

namespace RebusTest.EFCore.Models.DbModels
{
    public class Foo : ModelBase
    {
        public override int Id { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Text)}: {Text}";
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Foo) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TestId, Test, Text);
        }
    }
}