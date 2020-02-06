﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIMEFRAME_api.MODELS
{
    public class Project
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }

        // Relationships
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<TaskEntry> TaskEntries { get; set; }
    }
}
