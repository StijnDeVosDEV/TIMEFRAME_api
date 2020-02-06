﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIMEFRAME_api.MODELS
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string Status { get; set; }
    }
}
