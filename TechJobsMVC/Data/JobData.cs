using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechJobsMVC.Models;

namespace TechJobsMVC.Data
{
    public class JobData
    {
        private const string DATA_FILE = "Data/job_data.csv";

        private static bool _isDataLoaded = false;

        private static List<Job> _allJobs = new List<Job>();
        private static readonly List<JobField> _allEmployers = new List<JobField>();
        private static readonly List<JobField> _allLocations = new List<JobField>();
        private static readonly List<JobField> _allPositionTypes = new List<JobField>();
        private static readonly List<JobField> _allCoreCompetencies = new List<JobField>();

        public static List<Job> FindAll()
        {
            LoadData();

            return new List<Job>(_allJobs);
        }

        public static List<Job> FindByColumnAndValue(string column, string value)
        {
            column ??= "all";
            value ??= "all";

            LoadData();

            List<Job> jobs = new List<Job>();

            if (value.ToLower().Equals("all"))            
                return FindAll();
            

            if (column.Equals("all"))
            {
                jobs = FindByValue(value);
                return jobs;
            }
            foreach (Job job in _allJobs)
            {

                string aValue = GetFieldValue(job, column);

                if (aValue != null && aValue.ToLower().Contains(value.ToLower()))                
                    jobs.Add(job);                
            }

            return jobs;
        }

        public static string GetFieldValue(Job job, string fieldName)
        {
            string result;
            if (fieldName.Equals("name"))            
                result = job.Name;            
            else if (fieldName.Equals("employer"))            
                result = job.Employer.ToString();            
            else if (fieldName.Equals("location"))            
                result = job.Location.ToString();            
            else if (fieldName.Equals("positionType"))            
                result = job.PositionType.ToString();            
            else            
                result = job.CoreCompetency.ToString();           

            return result;
        }

        public static List<Job> FindByValue(string value)
        {
            // load data, if not already loaded
            LoadData();

            List<Job> jobs = new List<Job>();

            foreach (Job job in _allJobs)
            {
                if (job.Name != null && job.Name.ToLower().Contains(value.ToLower()))                
                    jobs.Add(job);                
                else if (job.Employer != null && job.Employer.ToString().ToLower().Contains(value.ToLower()))                
                    jobs.Add(job);                
                else if (job.Location.ToString().ToLower().Contains(value.ToLower()))                
                    jobs.Add(job);                
                else if (job.PositionType.ToString().ToLower().Contains(value.ToLower()))                
                    jobs.Add(job);                
                else if (job.CoreCompetency.ToString().ToLower().Contains(value.ToLower()))                
                    jobs.Add(job);
            }

            return jobs;
        }

        private static JobField? FindExistingObject(List<JobField> jobFields, string value)
        {
            foreach (JobField jobField in jobFields)
                if (jobField.ToString().ToLower().Equals(value.ToLower()))
                    return jobField;
            
            return null;
        }

        private static void LoadData()
        {
            if(_isDataLoaded)            
                return;            

            List<string[]> rows = new List<string[]>();

            using (StreamReader reader = File.OpenText(DATA_FILE))
            {
                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine() ?? "";
                    string[] rowArray = CSVRowToStringArray(line);
                    if (rowArray.Length > 0)                    
                        rows.Add(rowArray);
                    
                }
            }

            string[] headers = rows[0];
            rows.Remove(headers);

            _allJobs = new List<Job>();

            // Parse each row array 
            foreach (string[] row in rows)
            {
                string aName = row[0];
                string anEmployer = row[1];
                string aLocation = row[2];
                string aPositionType = row[3];
                string aCoreCompetency = row[4];

                if (!(FindExistingObject(_allEmployers, anEmployer) is Employer newEmployer))
                {
                    newEmployer = new Employer(anEmployer);
                    _allEmployers.Add(newEmployer);
                }

                if (!(FindExistingObject(_allLocations, aLocation) is Location newLocation))
                {
                    newLocation = new Location(aLocation);
                    _allLocations.Add(newLocation);
                }

                if (!(FindExistingObject(_allPositionTypes, aPositionType) is PositionType newPositionType))
                {
                    newPositionType = new PositionType(aPositionType);
                    _allPositionTypes.Add(newPositionType);
                }

                if (!(FindExistingObject(_allCoreCompetencies, aCoreCompetency) is CoreCompetency newCoreCompetency))
                {
                    newCoreCompetency = new CoreCompetency(aCoreCompetency);
                    _allCoreCompetencies.Add(newCoreCompetency);
                }

                Job newJob = new Job(aName, newEmployer, newLocation, newPositionType, newCoreCompetency);

                _allJobs.Add(newJob);
            }

            _isDataLoaded = true;
        }

        private static string[] CSVRowToStringArray(string row, char fieldSeparator = ',', char stringSeparator = '\"')
        {
            bool isBetweenQuotes = false;
            StringBuilder valueBuilder = new StringBuilder();
            List<string> rowValues = new List<string>();

            // Loop through the row string one char at a time
            foreach (char c in row.ToCharArray())
            {
                if ((c == fieldSeparator && !isBetweenQuotes))
                {
                    rowValues.Add(valueBuilder.ToString());
                    valueBuilder.Clear();
                }
                else
                {
                    if (c == stringSeparator)                    
                        isBetweenQuotes = !isBetweenQuotes;                    
                    else                    
                        valueBuilder.Append(c);                    
                }
            }

            // Add the final value
            rowValues.Add(valueBuilder.ToString());
            valueBuilder.Clear();

            return rowValues.ToArray();
        }

        public static List<JobField> GetAllEmployers()
        {
            LoadData();
            _allEmployers.Sort(new NameSorter());
            return _allEmployers;
        }

        public static List<JobField> GetAllLocations()
        {
            LoadData();
            _allLocations.Sort(new NameSorter());
            return _allLocations;
        }

        public static List<JobField> GetAllPositionTypes()
        {
            LoadData();
            _allPositionTypes.Sort(new NameSorter());
            return _allPositionTypes;
        }

        public static List<JobField> GetAllCoreCompetencies()
        {
            LoadData();
            _allCoreCompetencies.Sort(new NameSorter());
            return _allCoreCompetencies;
        }
    }
}
