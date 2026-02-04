using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using PlatformDemo.Core.Models;

namespace PlatformDemo.Core.Data;

public class AppDbContext : DbContext
{
    public DbSet<ServicePlan> ServicePlans { get; set; }
    public DbSet<Timesheet> Timesheets { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var servicePlans = new List<ServicePlan>();
        for (int i = 1; i <= 12; i++)
        {
            servicePlans.Add(new ServicePlan
            {
                Id = i,
                DateOfPurchase = DateTime.Now.AddDays(-i * 3)
            });
        }

        modelBuilder.Entity<ServicePlan>().HasData(servicePlans);

        var timesheets = new List<Timesheet>();
        int tsId = 1;
        var rand = new Random();

        foreach (var sp in servicePlans)
        {
            int count = rand.Next(0, 6);
            for (int i = 0; i < count; i++)
            {
                timesheets.Add(new Timesheet
                {
                    Id = tsId++,
                    ServicePlanId = sp.Id,
                    StartDateTime = DateTime.Now.AddHours(-rand.Next(1, 50)),
                    EndDateTime = DateTime.Now,
                    Description = "Seeded work log - Ken - " + sp.Id
                });
            }
        }

        modelBuilder.Entity<Timesheet>().HasData(timesheets);
    }

}

