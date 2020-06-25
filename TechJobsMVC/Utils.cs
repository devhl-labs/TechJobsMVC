using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TechJobsMVC.Models;

namespace TechJobsMVC
{
    public static class Utils
    {
        public const string DATA_NOT_AVAILABLE = "Data not available";

        //public static string JobsTable(List<Job> jobs)
        //{
        //    //viewContext.Writer.Write(
        //    string result =
        //        "<table class=\"job-listing\">" +
        //     "       <tr>                                                       " +
        //     "           <th>ID</th>                                            " +
        //     "           <th>Core</th>                                          " +
        //     "           <th>Name</th>                                          " +
        //     "           <th>Position</th>                                      " +
        //     "           <th>Employer</th>                                      " +
        //     "           <th>Location</th>                                      " +
        //     "       </tr>                                                      ";
        //    foreach(Job job in jobs)
        //    {
        //        result +=
        //     "   < tr >                                                         " +
        //     "       < td >                                                     " +
        //     $"           {job.Id}                                                " +
        //     "       </ td >                                                    " +
        //     "       < td >                                                     " +
        //     $"           {job.CoreCompetency}                                    " +
        //     "       </ td >                                                    " +
        //     "       < td >                                                     " +
        //     $"           {job.Name}                                              " +
        //     "       </ td >                                                    " +
        //     "       < td >                                                     " +
        //     $"           {job.PositionType}                                      " +
        //     "       </ td >                                                    " +
        //     "       < td >                                                     " +
        //    $"           {job.Employer}                                          " +
        //     "       </ td >                                                    " +
        //     "       < td >                                                     " +
        //     $"           {job.Location}                                          " +
        //     "       </ td >                                                    " +
        //     "   </ tr >";
        //    }

        //    result +=
        //     "   </table>                                                       ";
            

        //    return result;

        //    //return new HtmlDefaultPanel(html.ViewContext);
        //}
        

        //public class HtmlDefaultPanel : IDisposable
        //{
        //    private readonly ViewContext _viewContext;
        //    public HtmlDefaultPanel(ViewContext viewContext)
        //    {
        //        _viewContext = viewContext;
        //    }
        //    public void Dispose()
        //    {
        //        //_viewContext.Writer.Write(
        //        //"</div>" +
        //        //"</div>" +
        //        //"</div>"
        //        //);
        //    }
        //}
    }
}
