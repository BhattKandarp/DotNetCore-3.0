using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; } = 0;
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }
        public DateTime DOB { get; set; } = DateTime.Now;
    }
}
