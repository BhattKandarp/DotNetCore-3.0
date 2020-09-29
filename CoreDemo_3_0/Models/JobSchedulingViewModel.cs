using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Models
{
    public class JobSchedulingViewModel
    {
        public class JobScheduling
        {
            public int Id { get; set; }
            public string Subject { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string ThemeColor { get; set; }
            public bool IsFullDay { get; set; }
        }
    }
}
