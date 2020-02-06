using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIMEFRAME_app.MODELS
{
    public class TimeEntry
    {
        // Properties
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }

        // Relationships
        public int TaskEntryId { get; set; }
        public TaskEntry TaskEntry { get; set; }
    }
}
