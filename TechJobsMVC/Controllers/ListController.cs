using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class ListController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices { get; set; } = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"coreCompetency", "Skill"},
            {"positionType", "Position"},
            {"employer", "Employer"},
            {"location", "Location"}
        };
        internal static Dictionary<string, List<JobField>> TableChoices { get; set; } = new Dictionary<string, List<JobField>>()
        {
            {"employer", JobData.GetAllEmployers()},
            {"location", JobData.GetAllLocations()},
            {"positionType", JobData.GetAllPositionTypes()},
            {"coreCompetency", JobData.GetAllCoreCompetencies()}
        };

        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tableChoices = TableChoices;
            ViewBag.employers = JobData.GetAllEmployers();
            ViewBag.locations = JobData.GetAllLocations();
            ViewBag.positionTypes = JobData.GetAllPositionTypes();
            ViewBag.skills = JobData.GetAllCoreCompetencies();

            return View();
        }

        // list jobs by column and value
        public IActionResult Jobs(string column, string value)
        {
            List<Job> jobs;

            if (column.ToLower().Equals("all"))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(column, value);
                ViewBag.title = "Jobs with " + ColumnChoices[column] + ": " + value;
            }
            ViewBag.jobs = jobs;

            return View();
        }

    }
}
