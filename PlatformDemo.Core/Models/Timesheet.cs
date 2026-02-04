using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformDemo.Core.Models;

public class Timesheet
{
    public int Id { get; set; }

    public int ServicePlanId { get; set; }

    public ServicePlan? ServicePlan { get; set; }

    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public string Description { get; set; } = string.Empty;




}

