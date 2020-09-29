using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo_3_0.Entities
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string Department { get; set; }
    }
}
