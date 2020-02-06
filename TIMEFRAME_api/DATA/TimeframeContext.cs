using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TIMEFRAME_api.MODELS;

namespace TIMEFRAME_api.Data
{
    public class TimeframeContext : DbContext
    {
        public TimeframeContext (DbContextOptions<TimeframeContext> options)
            : base(options)
        {
        }

        public DbSet<TIMEFRAME_api.MODELS.Customer> Customer { get; set; }

        public DbSet<TIMEFRAME_api.MODELS.Project> Project { get; set; }

        public DbSet<TIMEFRAME_api.MODELS.TaskEntry> TaskEntry { get; set; }

        public DbSet<TIMEFRAME_api.MODELS.TimeEntry> TimeEntry { get; set; }
    }
}
