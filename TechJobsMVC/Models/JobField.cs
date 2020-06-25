using System;
namespace TechJobsMVC.Models
{
    public abstract class JobField
    {
        public int Id { get; }
        private static int _nextId = 1;

        public string Value { get; set; }

        public JobField(string value = Utils.DATA_NOT_AVAILABLE)
        {
            Id = _nextId;

            _nextId++;

            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            return obj is JobField field &&
                   Id == field.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
