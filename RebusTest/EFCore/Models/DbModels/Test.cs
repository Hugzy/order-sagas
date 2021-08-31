using System;

namespace RebusTest.EFCore.Models.DbModels
{
    public class Test : ModelBase
    {
        public override int Id { get; set; }
        public Foo Foo { get; set; }
        public string Text { get; set; }

        protected bool Equals(Test other)
        {
            return Id == other.Id && Equals(Foo, other.Foo) && Text == other.Text;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Test) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Foo, Text);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Id)}: {Id}, {nameof(Foo)}: {Foo}, {nameof(Text)}: {Text}";
        }
    }
}