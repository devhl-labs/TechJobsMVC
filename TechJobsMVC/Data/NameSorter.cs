using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TechJobsMVC.Models;

namespace TechJobsMVC.Data
{
    public class NameSorter : IComparer<JobField>
    {
        public int Compare(JobField? x, JobField? y)
        {
            return (x?.ToString() ?? Utils.DATA_NOT_AVAILABLE).ToLower().CompareTo((y?.ToString() ?? Utils.DATA_NOT_AVAILABLE).ToLower());
        }
    }
}
