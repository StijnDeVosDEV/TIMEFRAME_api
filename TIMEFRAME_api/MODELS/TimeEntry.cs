using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TIMEFRAME_api.MODELS
{
    public class TimeEntry
    {
        // Properties
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }

        // Relationships
        public int TaskEntryId { get; set; }
        public TaskEntry TaskEntry { get; set; }
    }
}
