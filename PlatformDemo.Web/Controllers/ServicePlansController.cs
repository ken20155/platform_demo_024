using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformDemo.Core.Data;
using PlatformDemo.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ServicePlansController : Controller
{
    private readonly AppDbContext _context;

    public ServicePlansController(AppDbContext context)
    {
        _context = context;
    }

    //public IActionResult Index()
    //{
    //    var data = _context.ServicePlans
    //        .Select(sp => new
    //        {
    //            sp.Id,
    //            sp.DateOfPurchase,
    //            TimesheetCount = sp.Timesheets.Count,
    //            TotalHours = sp.Timesheets.Sum(t =>
    //                EF.Functions.DateDiffMinute(t.StartDateTime, t.EndDateTime)) / 60.0
    //        })
    //        .ToList(); //read like a ancient language (Joke) //A lot of Logic for business rules and logic //good for command or crud operations 


    //    //var data = _context.Set<ServicePlan>()
    //    //            .FromSqlRaw(@"
    //    //                SELECT 
    //    //                    sp.Id,
    //    //                    sp.DateOfPurchase,
    //    //                    COUNT(ts.Id) AS TimesheetCount,
    //    //                    ISNULL(SUM(DATEDIFF(MINUTE, ts.StartDateTime, ts.EndDateTime)), 0) / 60.0 AS TotalHours
    //    //                FROM ServicePlans sp
    //    //                LEFT JOIN Timesheets ts 
    //    //                    ON ts.ServicePlanId = sp.Id
    //    //                GROUP BY 
    //    //                    sp.Id,
    //    //                    sp.DateOfPurchase
    //    //            ").ToList();//easy to read easy to understand, Good for Heavy queries, Example : Reports,Dashboards, Analytics,Heavy joins

    //    return View(data);
    //}
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Search(string term)
    {
        var data = _context.ServicePlans
            .Where(sp => string.IsNullOrEmpty(term) ||
                         sp.Id.ToString().Contains(term))
            .Select(sp => new
            {
                sp.Id,
                DateOfPurchase = sp.DateOfPurchase.ToShortDateString(),
                TimesheetCount = sp.Timesheets.Count,
                TotalHours = sp.Timesheets.Sum(t =>
                    EF.Functions.DateDiffMinute(t.StartDateTime, t.EndDateTime)) / 60.0
            })
            .ToList();

        return Json(data);
    }

}
