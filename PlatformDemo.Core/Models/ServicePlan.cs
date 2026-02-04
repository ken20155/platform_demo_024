using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformDemo.Core.Models;

public class ServicePlan
{
    public int Id { get; set; }

    public DateTime DateOfPurchase { get; set; }

    // Navigation property (1 ServicePlan → many Timesheets)
    public ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();

    public int TimesheetCount { get; set; }
    public decimal? TotalHours { get; set; }


}

