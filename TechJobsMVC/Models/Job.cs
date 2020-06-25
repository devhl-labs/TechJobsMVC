using System;
namespace TechJobsMVC.Models
{
    public class Job
    {

        public int Id { get; }
        private static int _nextId = 1;

        public string Name { get; set; } = Utils.DATA_NOT_AVAILABLE;
        public Employer Employer { get; set; } = new Employer();
        public Location Location { get; set; } = new Location();
        public PositionType PositionType { get; set; } = new PositionType();
        public CoreCompetency CoreCompetency { get; set; } = new CoreCompetency();

        public Job()
        {
            Id = _nextId;
            _nextId++;
        }

        public Job(string name, Employer employer, Location location, PositionType positionType, CoreCompetency coreCompetency) : this()
        {
            Name = name;
            Employer = employer;
            Location = location;
            PositionType = positionType;
            CoreCompetency = coreCompetency;
        }

        public override string ToString()
        {
            string output = string.Format("\nID: %d\n" +
                    "Name: %s\n" +
                    "Employer: %s\n" +
                    "Location: %s\n" +
                    "Position Type: %s\n" +
                    "Core Competency: %s\n", Id, Name, Employer, Location, PositionType, CoreCompetency);
            return output;
        }

        public override bool Equals(object? obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
