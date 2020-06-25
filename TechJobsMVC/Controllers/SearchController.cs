using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Server.IIS.Core;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{   
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;

            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.searchTerm = searchTerm;

            if (string.IsNullOrEmpty(searchType))
                ViewBag.searchType = "all";
            else
                ViewBag.searchType = searchType;

            if (string.IsNullOrEmpty(searchTerm))
                ViewBag.jobs = JobData.FindAll();
            else
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);

            ViewBag.columns = ListController.ColumnChoices;

            return View("Index");
        }
    }
}
